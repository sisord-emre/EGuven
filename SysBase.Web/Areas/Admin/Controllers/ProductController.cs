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
    public class ProductController : BaseController
    {
        // ProductController specific dependencies
        protected readonly IService<Product> _service;
        protected readonly IService<ProductLanguageInfo> _pageLanguageInfoService;
        protected readonly IService<Language> _languageService;
        protected readonly ILogger<ProductController> _logger;

        public ProductController(IHtmlLocalizer<SharedResource> localizer, UserManager<AppUser> userManager,
                              IService<Product> service, IService<ProductLanguageInfo> pageLanguageInfoService,
                              IService<Language> languageService, ILogger<ProductController> logger) : base(localizer, userManager)
        {
            _service = service;
            _pageLanguageInfoService = pageLanguageInfoService;
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

            Product model = null;
            if (Id != null)
            {
                model = await _service.GetByIdAsync(Int32.Parse(Id));
                model.ProductLanguageInfos = await _pageLanguageInfoService.Where(x => x.ProductId == model.Id).ToListAsync();
            }

            //log işleme alanı     
            LogContext.PushProperty("TypeName", "List");
            _logger.LogCritical(functions.LogCriticalMessage("List", ControllerContext.ActionDescriptor.ControllerName, Id));

            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var langCode = rqf.RequestCulture.Culture;

            return View(new ProductAddViewModel
            {
                MenuPermission = menuPermission,
                Product = model,
                Languages = await _languageService.GetAllAsync(),
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product model, IFormFile Image)
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            if (Image != null && Image.Length > 0)
            {
                model.Image = await functions.ImageUpload(Image, "Images/Product", Guid.NewGuid().ToString("N"));
            }
            else if (model.Id != 0)
            {
                var existing = await _service.Where(b => b.Id == model.Id).AsNoTracking().FirstOrDefaultAsync();
                model.Image = existing.Image;  // Eski resim tekrar set ediliyor
            }

            Product isControl;
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


            return View(new ProductAddViewModel
            {
                MenuPermission = menuPermission,
                Product = model,
                Languages = await _languageService.GetAllAsync(),
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

            return View(new ProductListViewModel { MenuPermission = menuPermission, ProductLanguageInfos = await _pageLanguageInfoService.Where(x => x.Language.Code == langCode.ToString()).Include(x => x.Product).ToListAsync() });
        }

        public async Task<IActionResult> Detail(string Id = null)
        {
            if (Id != null)
            {
                var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
                var langCode = rqf.RequestCulture.Culture;
                return View(await _pageLanguageInfoService.Where(x => x.Product.Id == Int32.Parse(Id) && x.Language.Code == langCode.ToString()).Include(x => x.Product).FirstOrDefaultAsync());
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
                Product item = await _service.GetByIdAsync(Int32.Parse(Id));
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
        public async Task<IActionResult> GorselKaldir(int id)
        {
            var item = _service.Where(x => x.Id == id).FirstOrDefault();
            if (item == null)
            {
                return NotFound($"Bulunamadı: ID = {id}");
            }
            item.Image = null;
            await _service.UpdateAsync(item);

            //log işleme alanı
            LogContext.PushProperty("TypeName", "Update");
            _logger.LogCritical(functions.LogCriticalMessage("Update", ControllerContext.ActionDescriptor.ControllerName, item.Id.ToString(), JsonConvert.SerializeObject(item)));

            return Ok(new { message = "Görsel başarıyla kaldırıldı." });
        }

    }
}
