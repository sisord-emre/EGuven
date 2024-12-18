using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog.Context;
using SysBase.Core.Models;
using SysBase.Core.Services;
using SysBase.Web.Areas.Admin.Models;
using SysBase.Web.Resources;

namespace SysBase.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class NotificationController : BaseController
    {
        // NotificationController specific dependencies
        protected readonly IService<Notification> _service;
        protected readonly IService<NotificationUser> _notificationUserService;
        protected readonly ILogger<NotificationController> _logger;

        public NotificationController(IHtmlLocalizer<SharedResource> localizer, UserManager<AppUser> userManager,
                                      IService<Notification> service, IService<NotificationUser> notificationUserService, 
                                      ILogger<NotificationController> logger)
            : base(localizer, userManager)
        {
            _service = service;
            _notificationUserService = notificationUserService;
            _logger = logger;
        }


        public async Task<IActionResult> Add(string Id = null)
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            // Şartlara göre kullanıcıları filtrele
            var appUsers = await _userManager.Users.ToListAsync();
            List<string> selectedUserIds = null;
            Notification model = null;
            if (Id != null)
            {
                model = await _service.GetByIdAsync(Int32.Parse(Id));
                model.NotificationUsers = await _notificationUserService
                    .Where(x => x.NotificationId == model.Id)
                    .ToListAsync();

                selectedUserIds = await _notificationUserService
                    .Where(bk => bk.NotificationId == Int32.Parse(Id))
                    .Select(bk => bk.UserId)
                    .ToListAsync();
            }

            //log işleme alanı     
            LogContext.PushProperty("TypeName", "List");
            _logger.LogCritical(functions.LogCriticalMessage("List", ControllerContext.ActionDescriptor.ControllerName, Id));

            return View
            (
                new NotificationAddViewModel
                {
                    MenuPermission = menuPermission,
                    Notification = model,
                    AppUsers = appUsers,
                    SelectedUserIds = selectedUserIds ?? new List<string>()
                }
            );
        }

        [HttpPost]
        public async Task<IActionResult> Add(Notification model, string[] userIdValue)
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            Notification isControl;
            if (ModelState.IsValid)
            {
                isControl = await _service.UpdateAsync(model);

                //log işleme alanı
                LogContext.PushProperty("TypeName", "Update");
                _logger.LogCritical(functions.LogCriticalMessage("Update", ControllerContext.ActionDescriptor.ControllerName, isControl.Id.ToString(), JsonConvert.SerializeObject(model)));
            }
            else
            {
                isControl = await _service.AddAsync(model);

                //log işleme alanı
                LogContext.PushProperty("TypeName", ControllerContext.ActionDescriptor.ActionName);
                _logger.LogCritical(functions.LogCriticalMessage(ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName, isControl.Id.ToString(), JsonConvert.SerializeObject(model)));
            }
            if (isControl.Id != 0)
            {
                // Mevcut NotificationUser kayıtlarını sil
                IEnumerable<NotificationUser> notificationUsers = await _notificationUserService.Where(x => x.NotificationId == model.Id).ToListAsync();
                await _notificationUserService.RemoveRangeAsync(notificationUsers);
                for (int i = 0; i < userIdValue.Length; i++)
                {
                    NotificationUser addItem = new NotificationUser();
                    addItem.NotificationId = isControl.Id;
                    addItem.UserId = userIdValue[i];
                    addItem.Visibility = true;

                    await _notificationUserService.AddAsync(addItem);
                }

                TempData["SuccessMessage"] = _localizer["admin.Kayıt İşlemi Başarıyle Gerçekleşmiştir."].Value;
            }
            else
            {
                TempData["ErrorMessage"] = _localizer["admin.Bilgileri Kontrol Ediniz"].Value;
            }

            model.NotificationUsers = await _notificationUserService.Where(x => x.NotificationId == isControl.Id).ToListAsync();

            // Şartlara göre kullanıcıları filtrele
            var appUsers = await _userManager.Users.ToListAsync();
            List<string> selectedUserIds = null;
            selectedUserIds = await _notificationUserService
                    .Where(bk => bk.NotificationId == isControl.Id)
                    .Select(bk => bk.UserId)
                    .ToListAsync();

            return View
            (
                new NotificationAddViewModel
                {
                    MenuPermission = menuPermission,
                    Notification = model,
                    AppUsers = appUsers,
                    SelectedUserIds = selectedUserIds ?? new List<string>()
                }
            );
        }

        public async Task<IActionResult> List()
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            // Şartlara göre kullanıcıları filtrele
            var appUsers = await _userManager.Users.ToListAsync();
            List<string> selectedUserIds = null;
            selectedUserIds = await _notificationUserService
                    .Where(bk => bk.Id > 0)
                    .Select(bk => bk.UserId)
                    .ToListAsync();

            //log işleme alanı
            LogContext.PushProperty("TypeName", ControllerContext.ActionDescriptor.ActionName);
            _logger.LogCritical(functions.LogCriticalMessage(ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName));

            return View
            (
               new NotificationListViewModel
               {
                   MenuPermission = menuPermission,
                   Notifications = await _service.Where(x => x.NotificationUsers.Any(nu => nu.NotificationId == x.Id && nu.Visibility == true)).Include(x => x.NotificationUsers).ToListAsync(),
                   AppUsers = appUsers,
                   SelectedUserIds = selectedUserIds ?? new List<string>()
               }
            );
        }

        public async Task<IActionResult> Detail(string Id = null)
        {
            if (Id != null)
            {
                // Şartlara göre kullanıcıları filtrele
                var appUserList = await _userManager.Users.ToListAsync();
                // Kullanıcı listesini ve seçili olanları ViewData ile gönder
                ViewData["appUserList"] = appUserList;
                return View(await _service.Where(x => x.Id == Int32.Parse(Id)).Include(x => x.NotificationUsers).FirstOrDefaultAsync());
            }

            //log işleme alanı
            LogContext.PushProperty("TypeName", "List");
            _logger.LogCritical(functions.LogCriticalMessage("List", ControllerContext.ActionDescriptor.ControllerName, Id));

            return View();
        }

        public async Task<ResultJson> Delete(string Id = null)
        {
            ResultJson resultJson = new ResultJson();
            resultJson.status = "error";
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                resultJson.message = _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value;
                return resultJson;
            }

            if (Id != null)
            {
                Notification item = await _service.GetByIdAsync(Int32.Parse(Id));
                if (item != null)
                {
                    List<NotificationUser> deletedNotificationUser = await _notificationUserService.Where(x => x.NotificationId == item.Id).AsNoTracking().ToListAsync();
                    foreach (var item1 in deletedNotificationUser)
                    {
                        NotificationUser addItem = new NotificationUser
                        {
                            Id = item1.Id,
                            NotificationId = item1.NotificationId,
                            UserId = item1.UserId,
                            ReadDate = item1.ReadDate,
                            Visibility = false
                        };
                        await _notificationUserService.UpdateAsync(addItem);
                    }

                    resultJson.status = "success";
                    return resultJson;
                }
            }

            //log işleme alanı
            LogContext.PushProperty("TypeName", ControllerContext.ActionDescriptor.ActionName);
            _logger.LogCritical(functions.LogCriticalMessage(ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName, Id));

            return resultJson;
        }

        public async Task<IActionResult> NotificationList()
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (currentUser?.Id != null)
            {
                // Görüntülenmemiş bildirimlerin sayısını hesaplıyoruz.
                int unseenNotificationCount = await _service.Where(x => x.NotificationUsers.Any(nu => !nu.ReadDate.HasValue && nu.UserId == currentUser.Id)).Include(x => x.NotificationUsers).CountAsync();

                // Bildirim listesini ve sayısını ViewModel'e ekliyoruz.
                var model = new NotificationListViewModel
                {
                    Notifications = await _service.Where(x => x.NotificationUsers.Any(nu => !nu.ReadDate.HasValue && nu.UserId == currentUser.Id)).Include(x => x.NotificationUsers).ToListAsync(),
                    UnseenNotificationCount = unseenNotificationCount
                };

                return View(model);
            }

            return View();
        }

        public async Task<IActionResult> UnseenNotificationCount()
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (currentUser?.Id != null)
            {
                int unseenNotificationCount = await _service.Where(x => x.NotificationUsers.Any(nu => !nu.ReadDate.HasValue && nu.UserId == currentUser.Id)).Include(x => x.NotificationUsers).CountAsync();

                return Json(new { UnseenNotificationCount = unseenNotificationCount });
            }

            return Json(new { UnseenNotificationCount = 0 });
        }

        [HttpPost]
        public async Task<IActionResult> NotificationRead()
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (currentUser?.Id != null)
            {
                // Kullanıcının görünmemiş bildirimlerini alıyoruz
                var notifications = await _service.Where(x => x.NotificationUsers.Any(nu => !nu.ReadDate.HasValue && nu.UserId == currentUser.Id)).Include(x => x.NotificationUsers).ToListAsync();

                int result = 0;

                foreach (var notification in notifications)
                {
                    var notificationUser = notification.NotificationUsers.FirstOrDefault(nu => nu.UserId == currentUser.Id && !nu.ReadDate.HasValue);
                    if (notificationUser != null)
                    {
                        notificationUser.ReadDate = DateTime.Now;

                        var updatedNotificationUser = await _notificationUserService.UpdateAsync(notificationUser);

                        if (updatedNotificationUser != null)
                        {
                            result++;
                        }

                        //log işleme alanı
                        LogContext.PushProperty("TypeName", "Update");
                        _logger.LogCritical(functions.LogCriticalMessage("Update", ControllerContext.ActionDescriptor.ControllerName, currentUser.Id.ToString(), JsonConvert.SerializeObject(notificationUser)));
                    }
                }

                if (result > 0)
                {
                    TempData["SuccessMessage"] = _localizer["admin.Kayıt İşlemi Başarıyle Gerçekleşmiştir."].Value;
                    return Json(1); // İşlem başarılı, 1 döndür
                }
                else
                {
                    TempData["ErrorMessage"] = _localizer["admin.Bilgileri Kontrol Ediniz"].Value;
                    return Json(0); // İşlem başarısız, 0 döndür
                }
            }

            return Json(0); // Kullanıcı ID'si null ise de 0 döndür
        }


        [HttpPost]
        public async Task<IActionResult> NotificationSingleRead(int id)
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (currentUser?.Id != null)
            {
                // Kullanıcının görünmemiş bildirimlerini alıyoruz
                var notifications = await _service
                    .Where(x => x.NotificationUsers.Any(nu => !nu.ReadDate.HasValue && nu.UserId == currentUser.Id && x.Id == id))
                    .Include(x => x.NotificationUsers)
                    .ToListAsync();

                int result = 0;

                foreach (var notification in notifications)
                {
                    var notificationUser = notification.NotificationUsers.FirstOrDefault(nu => nu.UserId == currentUser.Id && !nu.ReadDate.HasValue);

                    if (notificationUser != null)
                    {
                        notificationUser.ReadDate = DateTime.Now;

                        // Güncellenmiş notificationUser'ı veritabanına kaydet
                        var updatedNotificationUser = await _notificationUserService.UpdateAsync(notificationUser);

                        if (updatedNotificationUser != null)
                        {
                            result++;
                        }

                        //log işleme alanı
                        LogContext.PushProperty("TypeName", "Update");
                        _logger.LogCritical(functions.LogCriticalMessage("Update", ControllerContext.ActionDescriptor.ControllerName, currentUser.Id.ToString(), JsonConvert.SerializeObject(notificationUser)));
                    }
                }

                if (result > 0)
                {
                    TempData["SuccessMessage"] = _localizer["admin.Kayıt İşlemi Başarıyle Gerçekleşmiştir."].Value;
                    return Json(1); // İşlem başarılı, 1 döndür
                }
                else
                {
                    TempData["ErrorMessage"] = _localizer["admin.Bilgileri Kontrol Ediniz"].Value;
                    return Json(0); // İşlem başarısız, 0 döndür
                }
            }

            return Json(0); // Kullanıcı ID'si null ise de 0 döndür
        }
    }
}
