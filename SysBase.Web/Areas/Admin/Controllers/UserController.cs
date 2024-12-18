using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using ICSharpCode.Decompiler.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Serilog.Context;
using SysBase.Core.DTOs;
using SysBase.Core.Models;
using SysBase.Core.Services;
using SysBase.Service.Functions;
using SysBase.Web.Areas.Admin.Models;
using SysBase.Web.Resources;
using System.Composition;
using System.Diagnostics;

namespace SysBase.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class UserController : BaseController
    {
        // UserController specific dependency
        protected readonly IService<Menu> _service;
        protected readonly IService<AppRole> _appRoleService;
        protected readonly IService<AppUserRole> _aspNetUserRoleService;
        protected readonly ILogger<UserController> _logger;

        public UserController(IHtmlLocalizer<SharedResource> localizer, UserManager<AppUser> userManager,
                              IService<Menu> service, IService<AppRole> appRoleService,
                              IService<AppUserRole> aspNetUserRoleService, ILogger<UserController> logger)
            : base(localizer, userManager)
        {
            _service = service;
            _appRoleService = appRoleService;
            _aspNetUserRoleService = aspNetUserRoleService;
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

            AppUser user = null;
            List<string> selectedAppRoleIds = null;
            List<Menu> menus = await _service.Where(x => x.SpecialVisibility == true && x.UpMenuId == 0).OrderBy(x => x.Sequence).ToListAsync();
            List<AppRole> appRoles = await _appRoleService.Where(x => x.Status).ToListAsync();
            if (Id != null)
            {
                user = await _userManager.FindByIdAsync(Id);
                selectedAppRoleIds = (List<string>)await _userManager.GetRolesAsync(user);
            }

            //log işleme alanı     
            LogContext.PushProperty("TypeName", "List");
            _logger.LogCritical(functions.LogCriticalMessage("List", ControllerContext.ActionDescriptor.ControllerName, Id));

            return View
            (
                new UserAddViewModel
                {
                    MenuPermission = menuPermission,
                    Menus = menus,
                    AppUser = user,
                    AppRoles = appRoles,
                    SelectedAppRoleIds = selectedAppRoleIds ?? new List<string>()
                }
            );
        }

        [HttpPost]
        public async Task<IActionResult> Add(AppUser model, int[] List, int[] Add, int[] Edit, int[] Delete, int[] Export, string[] userIdValue)
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            List<Menu> menus = await _service.Where(x => x.SpecialVisibility == true && x.UpMenuId == 0).OrderBy(X => X.Sequence).ToListAsync();
            List<MenuPermission> menuPermissions = new List<MenuPermission>();
            foreach (Menu item in menus)
            {
                MenuPermission addItem = new MenuPermission();
                addItem.MenuId = item.Id;
                addItem.ControllerName = item.ControllerName;
                if (List.Contains(item.Id))
                {
                    addItem.List = true;
                }
                if (Add.Contains(item.Id))
                {
                    addItem.Add = true;
                }
                if (Edit.Contains(item.Id))
                {
                    addItem.Edit = true;
                }
                if (Delete.Contains(item.Id))
                {
                    addItem.Delete = true;
                }
                if (Export.Contains(item.Id))
                {
                    addItem.Export = true;
                }
                menuPermissions.Add(addItem);
            }
            string menuPermissionsJSON = JsonConvert.SerializeObject(menuPermissions);
            model.UserName = functions.ToSlug(model.Name + " " + model.SurName);
            //update
            if (model.Id != null)
            {
                AppUser user = await _userManager.FindByIdAsync(model.Id);
                user.Name = model.Name;
                user.SurName = model.SurName;
                user.Email = model.Email;
                user.NotificationStatus = model.NotificationStatus;
                user.Status = model.Status;
                user.MenuPermissions = menuPermissionsJSON;
                user.UserName = model.UserName;
                user.NormalizedUserName = _userManager.NormalizeName(model.UserName);
                IdentityResult isControl = await _userManager.UpdateAsync(user);
                if (isControl.Succeeded)
                {
                    // Mevcut AppUserRole kayıtlarını sil
                    IEnumerable<AppUserRole> aspNetUserRoles = await _aspNetUserRoleService.Where(x => x.UserId == model.Id).ToListAsync();
                    await _aspNetUserRoleService.RemoveRangeAsync(aspNetUserRoles);
                    for (int i = 0; i < userIdValue.Length; i++)
                    {
                        AppUserRole addItem = new AppUserRole();
                        addItem.UserId = model.Id;
                        addItem.RoleId = userIdValue[i];

                        await _aspNetUserRoleService.AddAsync(addItem);
                    }

                    TempData["SuccessMessage"] = _localizer["admin.Kayıt İşlemi Başarıyle Gerçekleşmiştir."].Value;
                }
                else
                {
                    TempData["ErrorMessage"] = _localizer["admin.Bilgileri Kontrol Ediniz"].Value;
                }

                if (model.PasswordHash != null)
                {
                    string token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    IdentityResult identityResult = await _userManager.ResetPasswordAsync(user, token, model.PasswordHash);
                    if (!identityResult.Succeeded)
                    {
                        foreach (IdentityError item in identityResult.Errors)
                        {
                            TempData["ErrorMessage"] += item.Description;
                            ModelState.AddModelError(string.Empty, item.Description);
                        }
                    }
                }

                //log işleme alanı
                LogContext.PushProperty("TypeName", "Update");
                _logger.LogCritical(functions.LogCriticalMessage("Update", ControllerContext.ActionDescriptor.ControllerName, model.Id, JsonConvert.SerializeObject(model)));
            }
            else
            {
                IdentityResult identityResult = await _userManager.CreateAsync
                (
                    new()
                    {
                        UserName = model.UserName,
                        Name = model.Name,
                        SurName = model.SurName,
                        Email = model.Email,
                        Status = model.Status,
                        NotificationStatus = model.NotificationStatus,
                        MenuPermissions = menuPermissionsJSON
                    },
                    model.PasswordHash
                );
                if (identityResult.Succeeded)
                {
                    TempData["SuccessMessage"] = _localizer["admin.Kayıt İşlemi Başarıyle Gerçekleşmiştir."].Value;

                    var hasUser = await _userManager.FindByEmailAsync(model.Email);
                    model.Id = hasUser.Id;

                    // Mevcut AppUserRole kayıtlarını sil
                    IEnumerable<AppUserRole> aspNetUserRoles = await _aspNetUserRoleService.Where(x => x.UserId == model.Id).ToListAsync();
                    await _aspNetUserRoleService.RemoveRangeAsync(aspNetUserRoles);
                    for (int i = 0; i < userIdValue.Length; i++)
                    {
                        AppUserRole addItem = new AppUserRole();
                        addItem.UserId = model.Id;
                        addItem.RoleId = userIdValue[i];

                        await _aspNetUserRoleService.AddAsync(addItem);
                    }

                }
                foreach (IdentityError item in identityResult.Errors)
                {
                    TempData["ErrorMessage"] += item.Description;
                    ModelState.AddModelError(string.Empty, item.Description);
                }

                //log işleme alanı
                LogContext.PushProperty("TypeName", ControllerContext.ActionDescriptor.ActionName);
                _logger.LogCritical(functions.LogCriticalMessage(ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName, model.Id, JsonConvert.SerializeObject(model)));
            }

            AppUser userRes = await _userManager.FindByIdAsync(model.Id);
            List<string> selectedAppRoleIds = null;
            selectedAppRoleIds = (List<string>)await _userManager.GetRolesAsync(userRes);
            List<AppRole> appRoles = await _appRoleService.Where(x => x.Status).ToListAsync();
            
            return View
            (
                new UserAddViewModel
                {
                    MenuPermission = menuPermission,
                    Menus = menus,
                    AppUser = userRes,
                    AppRoles = appRoles,
                    SelectedAppRoleIds = selectedAppRoleIds ?? new List<string>()
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

            //log işleme alanı
            LogContext.PushProperty("TypeName", ControllerContext.ActionDescriptor.ActionName);
            _logger.LogCritical(functions.LogCriticalMessage(ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName));

            return View(new UserListViewModel { MenuPermission = menuPermission, AppUsers = await _userManager.Users.ToListAsync() });
        }

        public async Task<IActionResult> Detail(string Id = null)
        {
            if (Id != null)
            {
                return View(await _userManager.FindByIdAsync(Id));
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
                var user = await _userManager.FindByIdAsync(Id);
                if (user != null)
                {
                    IdentityResult identityResult = await _userManager.DeleteAsync(user);
                    if (identityResult.Succeeded)
                    {
                        resultJson.status = "success";
                        return resultJson;
                    }
                    else
                    {
                        foreach (IdentityError item in identityResult.Errors)
                        {
                            resultJson.message += item.Description;
                            ModelState.AddModelError(string.Empty, item.Description);
                        }
                    }
                }
            }

            //log işleme alanı
            LogContext.PushProperty("TypeName", ControllerContext.ActionDescriptor.ActionName);
            _logger.LogCritical(functions.LogCriticalMessage(ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName, Id));

            return resultJson;
        }

        public async Task<IActionResult> Export()
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, "Export"))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            List<AppUser> userList = await _userManager.Users.ToListAsync();
            string tableName = ControllerContext.ActionDescriptor.ControllerName;
            string fileName = $"{tableName}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add(tableName);

            // Başlıklar
            worksheet.Cell(1, 1).Value = _localizer["admin.Ad Soyad"].Value;
            worksheet.Cell(1, 2).Value = _localizer["admin.Email"].Value;
            worksheet.Cell(1, 3).Value = _localizer["admin.Durumu"].Value;
            worksheet.Cell(1, 4).Value = _localizer["admin.Kayıt Tarihi"].Value;

            // İçerikler
            for (int i = 0; i < userList.Count; i++)
            {
                worksheet.Cell(i + 2, 1).Value = $"{userList[i].Name} {userList[i].SurName}";
                worksheet.Cell(i + 2, 2).Value = userList[i].Email;
                worksheet.Cell(i + 2, 3).Value = userList[i].Status ? "Aktif" : "Pasif";
                worksheet.Cell(i + 2, 4).Value = userList[i].CreatedDate.ToString("yyyy-MM-dd HH:mm:ss");
            }

            //log işleme alanı
            LogContext.PushProperty("TypeName", "Export");
            _logger.LogCritical(functions.LogCriticalMessage("Export", ControllerContext.ActionDescriptor.ControllerName, "", JsonConvert.SerializeObject(fileName)));

            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                var content = stream.ToArray();
                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }

        public async Task<IActionResult> AutomaticExportToExcelAsync()
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, "Export"))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            var listingExcel = await _userManager.Users
            .OrderByDescending(k => k.Id)
            .ToListAsync();

            // Excel dosyasını oluştur
            var fileContent = functions.AutomaticExportToExcel(listingExcel, ControllerContext.ActionDescriptor.ControllerName);
            string fileName = $"{ControllerContext.ActionDescriptor.ControllerName}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
            
            //log işleme alanı
            LogContext.PushProperty("TypeName", "Export");
            _logger.LogCritical(functions.LogCriticalMessage("Export", ControllerContext.ActionDescriptor.ControllerName, "", JsonConvert.SerializeObject(fileName)));
            
            return File(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }

        public async Task<IActionResult> ProfileList()
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, "Edit"))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            AppUser user = null;
            user = await _userManager.FindByIdAsync(currentUser.Id);

            //log işleme alanı
            LogContext.PushProperty("TypeName", "List");
            _logger.LogCritical(functions.LogCriticalMessage("List", ControllerContext.ActionDescriptor.ControllerName));

            return View(new UserAddViewModel { MenuPermission = menuPermission, AppUser = user });
        }

        [HttpPost]
        public async Task<IActionResult> ProfileUpdate(AppUser model)
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, "Edit"))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            model.UserName = functions.ToSlug(model.Name + " " + model.SurName);
            //update
            if (model.Id != null)
            {
                AppUser user = await _userManager.FindByIdAsync(model.Id);
                user.Name = model.Name;
                user.SurName = model.SurName;
                user.Email = model.Email;
                user.UserName = model.UserName;

                IdentityResult isControl = await _userManager.UpdateAsync(user);
                if (isControl.Succeeded)
                {
                    TempData["SuccessMessage"] = _localizer["admin.Kayıt İşlemi Başarıyle Gerçekleşmiştir."].Value;
                }
                else
                {
                    TempData["ErrorMessage"] = _localizer["admin.Bilgileri Kontrol Ediniz"].Value;
                }
            }

            AppUser userRes = await _userManager.FindByIdAsync(model.Id);

            //log işleme alanı
            LogContext.PushProperty("TypeName", "Update");
            _logger.LogCritical(functions.LogCriticalMessage("Update", ControllerContext.ActionDescriptor.ControllerName, model.Id, JsonConvert.SerializeObject(model)));

            return View("ProfileList", new UserAddViewModel { MenuPermission = menuPermission, AppUser = userRes });
        }

        public async Task<IActionResult> ChangePasswordList()
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, "Edit"))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            AppUser user = null;
            user = await _userManager.FindByIdAsync(currentUser.Id);

            //log işleme alanı
            LogContext.PushProperty("TypeName", "List");
            _logger.LogCritical(functions.LogCriticalMessage("List", ControllerContext.ActionDescriptor.ControllerName));

            return View(new UserAddViewModel { MenuPermission = menuPermission, AppUser = user });
        }

        [HttpPost]
        public async Task<IActionResult> ChangePasswordUpdate(AppUser model, string ConfirmPassword)
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, "Edit"))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            //update
            if (model.Id != null)
            {
                AppUser user = await _userManager.FindByIdAsync(model.Id);
                if (model.PasswordHash != null && ConfirmPassword != null)
                {
                    if (model.PasswordHash == ConfirmPassword)
                    {
                        string token = await _userManager.GeneratePasswordResetTokenAsync(user);
                        IdentityResult identityResult = await _userManager.ResetPasswordAsync(user, token, model.PasswordHash);
                        if (!identityResult.Succeeded)
                        {
                            foreach (IdentityError item in identityResult.Errors)
                            {
                                TempData["ErrorMessage"] += item.Description;
                                ModelState.AddModelError(string.Empty, item.Description);
                            }
                        }
                        else
                        {
                            TempData["SuccessMessage"] = _localizer["admin.Şifre Değiştirme İşlemi Başarıyle Gerçekleşmiştir."].Value;
                        }
                    }
                    else
                    {
                        TempData["ErrorMessage"] = _localizer["admin.Şifreler aynı olmalıdır"].Value;
                    }
                }
            }

            AppUser userRes = await _userManager.FindByIdAsync(model.Id);

            //log işleme alanı
            LogContext.PushProperty("TypeName", "Update");
            _logger.LogCritical(functions.LogCriticalMessage("Update", ControllerContext.ActionDescriptor.ControllerName, model.Id, JsonConvert.SerializeObject(model)));

            return View("ChangePasswordList", new UserAddViewModel { MenuPermission = menuPermission, AppUser = userRes });
        }

        [HttpPost]
        public async Task<IActionResult> UserNotificationChangeStatus(bool data)
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (currentUser?.Id != null)
            {
                AppUser user = await _userManager.FindByIdAsync(currentUser?.Id);

                user.NotificationStatus = data;
                IdentityResult isControl = await _userManager.UpdateAsync(user);
                if (isControl.Succeeded)
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
