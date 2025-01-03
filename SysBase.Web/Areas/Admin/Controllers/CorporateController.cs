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
    public class CorporateController : BaseController
    {
        // CorporateController specific dependencies
        protected readonly IService<Corporate> _service;
        protected readonly IService<CorporateLanguageInfo> _corporateLanguageInfoService;
        protected readonly IService<Language> _languageService;
        protected readonly ILogger<CorporateController> _logger;

        public CorporateController(IHtmlLocalizer<SharedResource> localizer, UserManager<AppUser> userManager,
                              IService<Corporate> service, IService<CorporateLanguageInfo> corporateLanguageInfoService,
                              IService<Language> languageService, ILogger<CorporateController> logger)
            : base(localizer, userManager)
        {
            _service = service;
            _corporateLanguageInfoService = corporateLanguageInfoService;
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

            Corporate model = null;
            model = await _service.GetByIdAsync(9);
            model.CorporateLanguageInfos = await _corporateLanguageInfoService.Where(x => x.CorporateId == model.Id).ToListAsync();
           
            //log işleme alanı     
            LogContext.PushProperty("TypeName", "List");
            _logger.LogCritical(functions.LogCriticalMessage("List", ControllerContext.ActionDescriptor.ControllerName, Id));

            return View(new CorporateAddViewModel { MenuPermission = menuPermission, Corporate = model, Languages = await _languageService.GetAllAsync() });
        }

        [HttpPost]
        public async Task<IActionResult> Add(Corporate model, List<IFormFile> images)
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            Corporate isControl;
            if (ModelState.IsValid)
            {
                model.UpdatedDate = DateTime.Now;
                // CorporateLanguageInfos içinde her dil için ayrı bir görsel yükleme işlemi
                if (images != null && images.Count > 0)
                {
                    for (int i = 0; i < model.CorporateLanguageInfos.Count; i++)
                    {
                        var image = images.ElementAtOrDefault(i);
                        if (image != null && image.Length > 0)
                        {
                            // Her dil için görseli yükleyip atıyoruz
                            model.CorporateLanguageInfos[i].Media = await functions.ImageUpload(image, "Images/Corporate", Guid.NewGuid().ToString("N"));
                        }
                    }
                }
                else if (model.Id != 0)
                {
                    var existing = await _corporateLanguageInfoService.Where(b => b.CorporateId == model.Id).AsNoTracking().FirstOrDefaultAsync();
                    for (int i = 0; i < model.CorporateLanguageInfos.Count; i++)
                    {
                        model.CorporateLanguageInfos[i].Media = existing.Media;  // Eski resim tekrar set ediliyor
                    }
                }

                isControl = await _service.UpdateAsync(model);

                //log işleme alanı
                LogContext.PushProperty("TypeName", "Update");
                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
                var json = JsonConvert.SerializeObject(model, settings);
                _logger.LogCritical(functions.LogCriticalMessage(
                    "Update",
                    ControllerContext.ActionDescriptor.ControllerName,
                    isControl.Id.ToString(),
                    json
                ));
            }
            else
            {
                model.Code = Guid.NewGuid().ToString("N");
                // CorporateLanguageInfos içinde her dil için ayrı bir görsel yükleme işlemi
                if (images != null && images.Count > 0)
                {
                    for (int i = 0; i < model.CorporateLanguageInfos.Count; i++)
                    {
                        var image = images.ElementAtOrDefault(i);
                        if (image != null && image.Length > 0)
                        {
                            // Her dil için görseli yükleyip atıyoruz
                            model.CorporateLanguageInfos[i].Media = await functions.ImageUpload(image, "Images/Corporate", Guid.NewGuid().ToString("N"));
                        }
                    }
                }
                isControl = await _service.AddAsync(model);

                //log işleme alanı
                LogContext.PushProperty("TypeName", ControllerContext.ActionDescriptor.ActionName);
                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
                var json = JsonConvert.SerializeObject(model, settings);
                _logger.LogCritical(functions.LogCriticalMessage(
                    ControllerContext.ActionDescriptor.ActionName,
                    ControllerContext.ActionDescriptor.ControllerName,
                    isControl.Id.ToString(),
                    json
                ));
                
            }
            if (isControl.Id != 0)
            {
                TempData["SuccessMessage"] = _localizer["admin.Kayıt İşlemi Başarıyle Gerçekleşmiştir."].Value;
            }
            else
            {
                TempData["ErrorMessage"] = _localizer["admin.Bilgileri Kontrol Ediniz"].Value;
            }

            return View(new CorporateAddViewModel { MenuPermission = menuPermission, Corporate = model, Languages = await _languageService.GetAllAsync() });
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

            return View(new CorporateListViewModel { MenuPermission = menuPermission, CorporateLanguageInfos = await _corporateLanguageInfoService.Where(x => x.Language.Code == langCode.ToString()).Include(x => x.Corporate).ToListAsync() });
        }

        public async Task<IActionResult> Detail(string Id = null)
        {
            if (Id != null)
            {
                var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
                var langCode = rqf.RequestCulture.Culture;
                return View(await _corporateLanguageInfoService.Where(x => x.Corporate.Id == Int32.Parse(Id) && x.Language.Code == langCode.ToString()).Include(x => x.Corporate).FirstOrDefaultAsync());
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
                Corporate item = await _service.GetByIdAsync(Int32.Parse(Id));
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

    }
}
