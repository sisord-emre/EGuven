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
using SysBase.Service.Functions;
using SysBase.Web.Areas.Admin.Models;
using SysBase.Web.Resources;
using System.Diagnostics;

namespace SysBase.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class SectorController : BaseController
    {
        // SectorController specific dependencies
        protected readonly IService<Sector> _service;
        protected readonly IService<SectorLanguageInfo> _sectorLanguageInfoService;
        protected readonly IService<Language> _languageService;
        protected readonly ILogger<SectorController> _logger;

        public SectorController(IHtmlLocalizer<SharedResource> localizer, UserManager<AppUser> userManager,
                              IService<Sector> service, IService<SectorLanguageInfo> sectorLanguageInfoService,
                              IService<Language> languageService, ILogger<SectorController> logger)
            : base(localizer, userManager)
        {
            _service = service;
            _sectorLanguageInfoService = sectorLanguageInfoService;
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

            Sector model = null;
            if (Id != null)
            {
                model = await _service.GetByIdAsync(Int32.Parse(Id));
                model.SectorLanguageInfos = await _sectorLanguageInfoService.Where(x => x.SectorId == model.Id).ToListAsync();
            }

            //log işleme alanı     
            LogContext.PushProperty("TypeName", "List");
            _logger.LogCritical(functions.LogCriticalMessage("List", ControllerContext.ActionDescriptor.ControllerName, Id));

            return View(new SectorAddViewModel { MenuPermission = menuPermission, Sector = model, Languages = await _languageService.GetAllAsync() });
        }

        [HttpPost]
        public async Task<IActionResult> Add(Sector model)
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            Sector isControl;
            if (ModelState.IsValid)
            {
                model.UpdatedDate = DateTime.Now;
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

            return View(new SectorAddViewModel { MenuPermission = menuPermission, Sector = model, Languages = await _languageService.GetAllAsync() });
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

            return View(new SectorListViewModel { MenuPermission = menuPermission, SectorLanguageInfos = await _sectorLanguageInfoService.Where(x => x.Language.Code == langCode.ToString()).Include(x => x.Sector).ToListAsync() });
        }

        public async Task<IActionResult> Detail(string Id = null)
        {
            if (Id != null)
            {
                var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
                var langCode = rqf.RequestCulture.Culture;
                return View(await _sectorLanguageInfoService.Where(x => x.Sector.Id == Int32.Parse(Id) && x.Language.Code == langCode.ToString()).Include(x => x.Sector).FirstOrDefaultAsync());
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
                Sector item = await _service.GetByIdAsync(Int32.Parse(Id));
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
