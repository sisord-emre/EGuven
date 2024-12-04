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
using System.Globalization;

namespace SysBase.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class SoftwareController : BaseController
    {
        // SoftwareController specific dependencies
        protected readonly IService<Software> _service;
        protected readonly IService<SoftwareLanguageInfo> _pageLanguageInfoService;
        protected readonly IService<Language> _languageService;
        protected readonly ILogger<SoftwareController> _logger;
        protected readonly IService<SoftwareCategoryLanguageInfo> _softwareCategoryLanguageInfoService;

        public SoftwareController(IHtmlLocalizer<SharedResource> localizer, UserManager<AppUser> userManager,
                              IService<Software> service, IService<SoftwareLanguageInfo> pageLanguageInfoService,
                              IService<Language> languageService, ILogger<SoftwareController> logger, IService<SoftwareCategoryLanguageInfo> softwareCategoryLanguageInfoService) : base(localizer, userManager)
        {
            _service = service;
            _pageLanguageInfoService = pageLanguageInfoService;
            _languageService = languageService;
            _logger = logger;
            _softwareCategoryLanguageInfoService = softwareCategoryLanguageInfoService;
        }

        public async Task<IActionResult> Add(string Id = null)
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            Software model = null;
            if (Id != null)
            {
                model = await _service.GetByIdAsync(Int32.Parse(Id));
                model.SoftwareLanguageInfos = await _pageLanguageInfoService.Where(x => x.SoftwareId == model.Id).ToListAsync();
            }

            //log işleme alanı     
            LogContext.PushProperty("TypeName", "List");
            _logger.LogCritical(functions.LogCriticalMessage("List", ControllerContext.ActionDescriptor.ControllerName, Id));

            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var langCode = rqf.RequestCulture.Culture;

            return View(new SoftwareAddViewModel
            {
                MenuPermission = menuPermission,
                Software = model,
                Languages = await _languageService.GetAllAsync(),
                SoftwareCategoryLanguageInfos = await _softwareCategoryLanguageInfoService.Where(x => x.Language.Code == CultureInfo.CurrentCulture.Name).Include(x => x.Language).ToListAsync()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add(Software model)
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            var uploadedFiles = HttpContext.Request.Form.Files;
            for (int i = 0; i < model.SoftwareLanguageInfos.Count; i++)
            {
                var file = uploadedFiles.FirstOrDefault(f => f.Name == $"SoftwareLanguageInfos[{i}].File");
                if (file != null && file.Length > 0)
                {
                    string[] allowedExtensions = { ".exe", ".zip", ".rar" };
                    model.SoftwareLanguageInfos[i].File = await functions.FileUpload(file, "Images/Software", Guid.NewGuid().ToString("N"), allowedExtensions);
                }
            }

            Software isControl;
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
                model.Code = Guid.NewGuid().ToString("N");
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


            return View(new SoftwareAddViewModel
            {
                MenuPermission = menuPermission,
                Software = model,
                Languages = await _languageService.GetAllAsync(),
                SoftwareCategoryLanguageInfos = await _softwareCategoryLanguageInfoService.Where(x => x.Language.Code == CultureInfo.CurrentCulture.Name).Include(x => x.Language).ToListAsync()
            });
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

            return View(new SoftwareListViewModel { MenuPermission = menuPermission, SoftwareLanguageInfos = await _pageLanguageInfoService.Where(x => x.Language.Code == langCode.ToString()).Include(x => x.Software).ToListAsync() });
        }

        public async Task<IActionResult> Detail(string Id = null)
        {
            if (Id != null)
            {
                var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
                var langCode = rqf.RequestCulture.Culture;
                return View(await _pageLanguageInfoService.Where(x => x.Software.Id == Int32.Parse(Id) && x.Language.Code == langCode.ToString()).Include(x => x.Software).FirstOrDefaultAsync());
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
                Software item = await _service.GetByIdAsync(Int32.Parse(Id));
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
