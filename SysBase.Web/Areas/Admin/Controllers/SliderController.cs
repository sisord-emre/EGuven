using ICSharpCode.Decompiler.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog.Context;
using SysBase.Core.DTOs;
using SysBase.Core.Models;
using SysBase.Core.Services;
using SysBase.Repository.Migrations;
using SysBase.Service.Functions;
using SysBase.Web.Areas.Admin.Models;
using SysBase.Web.Resources;

namespace SysBase.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class SliderController : BaseController
    {
        // SliderController specific dependencies
        protected readonly IService<Slider> _service;
        protected readonly ILogger<SliderController> _logger;
        protected readonly IService<Language> _languageService;

        public SliderController(IHtmlLocalizer<SharedResource> localizer, UserManager<AppUser> userManager,
                                  IService<Slider> service,ILogger<SliderController> logger, IService<Language> languageService)
            : base(localizer, userManager)
        {
            _service = service;   
            _logger = logger;
            _languageService = languageService;
        }

        public async Task<IActionResult> Add(string Id = null)
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            Slider slider = null;
            if (Id != null)
            {
                slider = await _service.GetByIdAsync(Int32.Parse(Id));
            }

            //log işleme alanı     
            LogContext.PushProperty("TypeName", "List");
            _logger.LogCritical(functions.LogCriticalMessage("List", ControllerContext.ActionDescriptor.ControllerName, Id));

            return View
            (
                new SliderAddViewModel 
                { 
                    MenuPermission = menuPermission, 
                    Slider = slider, 
                    Languages = (List<Language>)await _languageService.GetAllAsync() 
                }
            );
        }

        [HttpPost]
        public async Task<IActionResult> Add(Slider model, IFormFile Image)
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            if (Image != null && Image.Length > 0)
            {
                model.Media = await functions.ImageUpload(Image, "Images/Slider", Guid.NewGuid().ToString("N"));
            }
            else if (model.Id != 0)
            {
                var existing = await _service.Where(b => b.Id == model.Id).AsNoTracking().FirstOrDefaultAsync();
                model.Media = existing.Media;  // Eski resim tekrar set ediliyor
            }

            Slider isControl;
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
                TempData["SuccessMessage"] = _localizer["admin.Kayıt İşlemi Başarıyle Gerçekleşmiştir."].Value;
            }
            else
            {
                TempData["ErrorMessage"] = _localizer["admin.Bilgileri Kontrol Ediniz"].Value;
            }
         
            return View
            (
                new SliderAddViewModel
                {
                    MenuPermission = menuPermission,
                    Slider = isControl,
                    Languages = (List<Language>)await _languageService.GetAllAsync()
                }
            );
        }

        public async Task<IActionResult> List()
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                return Content("" +
                    "<div class='alert alert-danger alert-dismissible fade show' role='alert'>" +
                        "<strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong>" +
                    "</div>");
            }

            //log işleme alanı
            LogContext.PushProperty("TypeName", ControllerContext.ActionDescriptor.ActionName);
            _logger.LogCritical(functions.LogCriticalMessage(ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName));

            return View(new SliderListViewModel { MenuPermission = menuPermission, Sliders = await _service.GetAllAsync() });
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
                Slider item = await _service.GetByIdAsync(Int32.Parse(Id));
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

        public async Task<IActionResult> SliderLayout(int sliderLanguageId)
        {
            var orderedSliders = await _service
               .Where(x => x.LanguageId == sliderLanguageId)
               .Include(x => x.Language) // Language varlığını sorguya dahil ediyoruz
               .OrderBy(s => s.Sequence)
               .ToListAsync();

            return View(orderedSliders);

        }

        [HttpPost]
        public async Task<IActionResult> SliderLayoutAdd([FromBody] SliderLayoutModel model)
        {
            try
            {
                // sliderLayoutList ile slider sırasını güncelleme işlemi
                int sayac1 = 0;
                foreach (var sliderId in model.SliderLayoutList)
                {
                    sayac1++;
                    Slider item = await _service.GetByIdAsync(sliderId);
                    item.Sequence = sayac1;
                    await _service.UpdateAsync(item);
                }

                // Başarılı bir işlem olduğunda
                return Json(new { success = true, message = "Güncelleme Sağlandı." });
            }
            catch (Exception ex)
            {
                // Hata durumunda
                return Json(new { success = false, message = ex.Message });
            }
        }

    }
}
