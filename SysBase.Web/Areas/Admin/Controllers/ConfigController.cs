using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    public class ConfigController : BaseController
    {
        // ConfigController specific dependencies
        protected readonly IService<Config> _service;
        protected readonly IService<ConfigLanguageInfo> _configLanguageInfoService;
        protected readonly IService<Language> _languageService;
        protected readonly ILogger<ConfigController> _logger;

        public ConfigController(IHtmlLocalizer<SharedResource> localizer, UserManager<AppUser> userManager,
                                IService<Config> service, IService<ConfigLanguageInfo> configLanguageInfoService,
                                IService<Language> languageService, ILogger<ConfigController> logger)
            : base(localizer, userManager)
        {
            _service = service;
            _configLanguageInfoService = configLanguageInfoService;
            _languageService = languageService;
            _logger = logger;
        }

        public async Task<IActionResult> Add()
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            Config model = null;
            model = await _service.GetByIdAsync(1);
            model.ConfigLanguageInfos = await _configLanguageInfoService.Where(x => x.ConfigId == model.Id).ToListAsync();

            //log işleme alanı     
            LogContext.PushProperty("TypeName", "List");
            _logger.LogCritical(functions.LogCriticalMessage("List", ControllerContext.ActionDescriptor.ControllerName));

            return View(new ConfigAddViewModel { MenuPermission = menuPermission, Config = model, Languages = await _languageService.GetAllAsync() });
        }

        [HttpPost]
        public async Task<IActionResult> Add(Config model)
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            Config isControl;
            if (model.Id > 0) // Id kontrolü eklendi
            {
                isControl = await _service.UpdateAsync(model);
            }
            else
            {
                isControl = await _service.AddAsync(model);
            }
            if (isControl.Id != 0)
            {
                TempData["SuccessMessage"] = _localizer["admin.Kayıt İşlemi Başarıyle Gerçekleşmiştir."].Value;
            }
            else
            {
                TempData["ErrorMessage"] = _localizer["admin.Bilgileri Kontrol Ediniz"].Value;
            }

            //log işleme alanı
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            LogContext.PushProperty("TypeName", "Update");
            _logger.LogCritical(functions.LogCriticalMessage("Update", ControllerContext.ActionDescriptor.ControllerName, isControl.Id.ToString(), JsonConvert.SerializeObject(model, settings)));

            return View(new ConfigAddViewModel { MenuPermission = menuPermission, Config = model, Languages = await _languageService.GetAllAsync() });
        }
    }
}
