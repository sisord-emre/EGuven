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
    public class HomeProductController : BaseController
    {
        // HomeProductController specific dependencies
        protected readonly IService<HomeProduct> _service;
        protected readonly IService<HomeProductLanguageInfo> _pageLanguageInfoService;
        protected readonly IService<Language> _languageService;
        protected readonly IService<Config> _configService;
        protected readonly IService<HomeProductSequence> _homeProductSequenceService;
        protected readonly ILogger<HomeProductController> _logger;

        public HomeProductController(IHtmlLocalizer<SharedResource> localizer, UserManager<AppUser> userManager,
                              IService<HomeProduct> service, IService<HomeProductLanguageInfo> pageLanguageInfoService,
                              IService<Config> configService, IService<HomeProductSequence> homeProductSequenceService,
                              IService<Language> languageService, ILogger<HomeProductController> logger) : base(localizer, userManager)
        {
            _service = service;
            _pageLanguageInfoService = pageLanguageInfoService;
            _languageService = languageService;
            _configService = configService;
            _homeProductSequenceService = homeProductSequenceService;
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

            HomeProduct model = null;
            if (Id != null)
            {
                model = await _service.GetByIdAsync(Int32.Parse(Id));
                model.HomeProductLanguageInfos = await _pageLanguageInfoService.Where(x => x.HomeProductId == model.Id).ToListAsync();
            }

            //log işleme alanı     
            LogContext.PushProperty("TypeName", "List");
            _logger.LogCritical(functions.LogCriticalMessage("List", ControllerContext.ActionDescriptor.ControllerName, Id));

            return View(new HomeProductAddViewModel { MenuPermission = menuPermission, HomeProduct = model, Languages = await _languageService.GetAllAsync() });
        }

        [HttpPost]
        public async Task<IActionResult> Add(HomeProduct model)
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            HomeProduct isControl;
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


            return View(new HomeProductAddViewModel { MenuPermission = menuPermission, HomeProduct = model, Languages = await _languageService.GetAllAsync() });
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

            return View(
                new HomeProductListViewModel 
                { 
                    MenuPermission = menuPermission, 
                    HomeProductLanguageInfos = await _pageLanguageInfoService.Where(x => x.Language.Code == langCode.ToString()).Include(x => x.HomeProduct).ToListAsync(),
                    Config = await _configService.GetByIdAsync(1),
                    HomeProductSequences = await _homeProductSequenceService.GetAllAsync()
                });
        }

        public async Task<IActionResult> Detail(string Id = null)
        {
            if (Id != null)
            {
                var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
                var langCode = rqf.RequestCulture.Culture;
                return View(await _pageLanguageInfoService.Where(x => x.HomeProduct.Id == Int32.Parse(Id) && x.Language.Code == langCode.ToString()).Include(x => x.HomeProduct).FirstOrDefaultAsync());
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
                HomeProduct item = await _service.GetByIdAsync(Int32.Parse(Id));
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
        public async Task<ResultJson> HomeProductSequenceAdd(string Id = null)
        {
            ResultJson resultJson = new ResultJson { status = "error" };

            try
            {
                Config isControl = null;

                if (!string.IsNullOrEmpty(Id)) // Id boş değilse
                {
                    // string Id'yi int'e dönüştür
                    if (int.TryParse(Id, out int numericId)) // Güvenli dönüşüm
                    {
                        // Önce güncellenecek kaydı bul
                        var existingConfig = await _configService.GetByIdAsync(1);
                        if (existingConfig != null)
                        {
                            // Güncellenecek alanı değiştir
                            existingConfig.HomeProductSequenceId = numericId;

                            // Değişiklikleri kaydet
                            isControl = await _configService.UpdateAsync(existingConfig);

                            //log işleme alanı
                            LogContext.PushProperty("TypeName", "Update");
                            _logger.LogCritical(functions.LogCriticalMessage("Update", ControllerContext.ActionDescriptor.ControllerName, isControl.Id.ToString(), JsonConvert.SerializeObject(existingConfig)));
                        }
                        else
                        {
                            resultJson.message = _localizer["admin.Kayıt bulunamadı."].Value;
                            return resultJson;
                        }
                    }
                    else
                    {
                        resultJson.message = _localizer["admin.Geçersiz Id formatı."].Value;
                        return resultJson;
                    }
                }
                else
                {
                    resultJson.message = _localizer["admin.Geçersiz Id."].Value;
                    return resultJson;
                }

                // Güncelleme başarılı mı kontrol et
                if (isControl != null && isControl.Id != 0)
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

    }
}
