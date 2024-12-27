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
    public class HomeTabPostController : BaseController
    {
        // HomeTabPostController specific dependencies
        protected readonly IService<HomeTabPost> _service;
        protected readonly IService<HomeTabPostLanguageInfo> _homeTabPostLanguageInfoService;
        protected readonly IService<HomeTabPostLanguageInfoContent> _homeTabPostLanguageInfoContentService;
        protected readonly IService<Language> _languageService;
        protected readonly ILogger<HomeTabPostController> _logger;

        public HomeTabPostController(IHtmlLocalizer<SharedResource> localizer, UserManager<AppUser> userManager,
                              IService<HomeTabPost> service, IService<HomeTabPostLanguageInfo> homeTabPostLanguageInfoService,
                              IService<HomeTabPostLanguageInfoContent> homeTabPostLanguageInfoContentService,
                              IService<Language> languageService, ILogger<HomeTabPostController> logger) : base(localizer, userManager)
        {
            _service = service;
            _homeTabPostLanguageInfoService = homeTabPostLanguageInfoService;
            _homeTabPostLanguageInfoContentService = homeTabPostLanguageInfoContentService;
            _languageService = languageService;
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

            HomeTabPost model = null;
            if (Id != null)
            {
                model = await _service.GetByIdAsync(Int32.Parse(Id));
                model.HomeTabPostLanguageInfos = await _homeTabPostLanguageInfoService
                    .Where(x => x.HomeTabPostId == model.Id)
                    .Include(x => x.HomeTabPostLanguageInfoContents)
                    .ToListAsync();
            }

            //log işleme alanı     
            LogContext.PushProperty("TypeName", "List");
            _logger.LogCritical(functions.LogCriticalMessage("List", ControllerContext.ActionDescriptor.ControllerName, Id));

            return View(new HomeTabPostAddViewModel { MenuPermission = menuPermission, HomeTabPost = model, Languages = await _languageService.GetAllAsync() });
        }

        [HttpPost]
        public async Task<IActionResult> Add(HomeTabPost model)
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            HomeTabPost existingBlog = null;
            if (model.Id != 0)
            {
                existingBlog = await _service.Where(b => b.Id == model.Id).AsNoTracking().FirstOrDefaultAsync();
            }

            HomeTabPost isControl;
            if (model.Id != 0)  // Güncelleme işlemi
            {
                model.UpdatedDate = DateTime.Now;
                isControl = await _service.UpdateAsync(model);

                //log işleme alanı
                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
                LogContext.PushProperty("TypeName", "Update");
                _logger.LogCritical(functions.LogCriticalMessage("Update", ControllerContext.ActionDescriptor.ControllerName, isControl.Id.ToString(), JsonConvert.SerializeObject(model, settings)));
            }
            else  // Ekleme işlemi
            {
                isControl = await _service.AddAsync(model);

                //log işleme alanı
                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
                LogContext.PushProperty("TypeName", ControllerContext.ActionDescriptor.ActionName);
                _logger.LogCritical(functions.LogCriticalMessage(ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName, isControl.Id.ToString(), JsonConvert.SerializeObject(model, settings)));
            }

            if (isControl.Id != 0)
            {
                TempData["SuccessMessage"] = _localizer["admin.Kayıt İşlemi Başarıyle Gerçekleşmiştir."].Value;
            }
            else
            {
                TempData["ErrorMessage"] = _localizer["admin.Bilgileri Kontrol Ediniz"].Value;
            }


            return View(new HomeTabPostAddViewModel { MenuPermission = menuPermission, HomeTabPost = model, Languages = await _languageService.GetAllAsync() });
        }

        public async Task<IActionResult> List()
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }
            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var langCode = rqf.RequestCulture.Culture;

            //log işleme alanı
            LogContext.PushProperty("TypeName", ControllerContext.ActionDescriptor.ActionName);
            _logger.LogCritical(functions.LogCriticalMessage(ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName));

            return View(new HomeTabPostListViewModel { MenuPermission = menuPermission, HomeTabPostLanguageInfos = await _homeTabPostLanguageInfoService.Where(x => x.Language.Code == langCode.ToString()).Include(x => x.HomeTabPost).ToListAsync() });
        }

        public async Task<IActionResult> Detail(string Id = null)
        {
            if (Id != null)
            {
                var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
                var langCode = rqf.RequestCulture.Culture;
                return View(await _homeTabPostLanguageInfoService.Where(x => x.HomeTabPost.Id == Int32.Parse(Id) && x.Language.Code == langCode.ToString()).Include(x => x.HomeTabPost).FirstOrDefaultAsync());
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
                HomeTabPost item = await _service.GetByIdAsync(Int32.Parse(Id));
                if (item != null)
                {
                    await _service.RemoveAsync(item);
                    resultJson.status = "success";
                    return resultJson;
                }
            }

            //log işleme alanı
            LogContext.PushProperty("TypeName", ControllerContext.ActionDescriptor.ActionName);
            _logger.LogCritical(functions.LogCriticalMessage(ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName, Id));

            return resultJson;
        }

        [HttpPost]
        public async Task<ResultJson> SubUnitRecord(HomeTabPostLanguageInfoContent model)
        {
            ResultJson resultJson = new ResultJson { status = "error" };

            try
            {
                HomeTabPostLanguageInfoContent isControl;
                if (model.Id != 0)
                {
                    // Güncelleme işlemi
                    model.UpdatedDate = DateTime.Now;
                    isControl = await _homeTabPostLanguageInfoContentService.UpdateAsync(model);


                    //log işleme alanı
                    LogContext.PushProperty("TypeName", "Update");
                    _logger.LogCritical(functions.LogCriticalMessage("Update", ControllerContext.ActionDescriptor.ControllerName, isControl.Id.ToString(), JsonConvert.SerializeObject(model)));
                }
                else
                {
                    isControl = await _homeTabPostLanguageInfoContentService.AddAsync(model);

                    //log işleme alanı
                    LogContext.PushProperty("TypeName", ControllerContext.ActionDescriptor.ActionName);
                    _logger.LogCritical(functions.LogCriticalMessage(ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName, isControl.Id.ToString(), JsonConvert.SerializeObject(model)));
                }

                // Veritabanı değişikliklerini kaydetme
                if (isControl.Id != 0)
                {
                    resultJson.status = "success";
                }
                else
                {
                    resultJson.message = _localizer["admin.Bir hata oluştu."].Value;
                }
            }
            catch (Exception ex)
            {
                resultJson.message = $"Hata: {ex.Message}";
            }

            return resultJson;
        }

        public async Task<IActionResult> SubUnitList(int id)
        {
            //log işleme alanı
            LogContext.PushProperty("TypeName", ControllerContext.ActionDescriptor.ActionName);
            _logger.LogCritical(functions.LogCriticalMessage(ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName));

            var subUnits = await _homeTabPostLanguageInfoContentService
                .Where(x => x.Sequence > 0)
                .Include(x => x.HomeTabPostLanguageInfo.HomeTabPost)
                .Where(x => x.HomeTabPostLanguageInfo.HomeTabPostId == id)
                .ToListAsync();

            var viewModel = new HomeTabPostLanguageInfoContentSubUnitViewModel
            {
                HomeTabPostLanguageInfoContents = subUnits
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ResultJson> SubUnitDelete(int id)
        {
            ResultJson resultJson = new ResultJson { status = "error" };

            try
            {
                var item = await _homeTabPostLanguageInfoContentService.GetByIdAsync(id);
                if (item != null)
                {
                    await _homeTabPostLanguageInfoContentService.RemoveAsync(item);
                    resultJson.status = "success";

                    //log işleme alanı
                    LogContext.PushProperty("TypeName", ControllerContext.ActionDescriptor.ActionName);
                    _logger.LogCritical(functions.LogCriticalMessage(ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName, JsonConvert.SerializeObject(item)));
                }
                else
                {
                    resultJson.message = _localizer["admin.Silinecek kayıt bulunamadı."].Value;
                }
            }
            catch (Exception ex)
            {
                resultJson.message = $"Hata: {ex.Message}";
            }

            return resultJson;
        }



    }
}
