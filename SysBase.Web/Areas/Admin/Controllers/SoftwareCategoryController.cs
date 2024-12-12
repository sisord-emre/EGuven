using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2010.Excel;
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
    public class SoftwareCategoryController : BaseController
    {
        // SoftwareCategoryController specific dependencies
        protected readonly IService<SoftwareCategory> _service;
        protected readonly IService<SoftwareCategoryLanguageInfo> _softwareCategoryLanguageInfo;
        protected readonly IService<SoftwareCategoryLanguageInfoContent> _softwareCategoryLanguageInfoContentService;
        protected readonly IService<Language> _languageService;
        protected readonly ILogger<SoftwareCategoryController> _logger;

        public SoftwareCategoryController(IHtmlLocalizer<SharedResource> localizer, UserManager<AppUser> userManager,
                              IService<SoftwareCategory> service, IService<SoftwareCategoryLanguageInfo> softwareCategoryLanguageInfo,
                              IService<SoftwareCategoryLanguageInfoContent> softwareCategoryLanguageInfoContentService,
                              IService<Language> languageService, ILogger<SoftwareCategoryController> logger) : base(localizer, userManager)
        {
            _service = service;
            _softwareCategoryLanguageInfo = softwareCategoryLanguageInfo;
            _softwareCategoryLanguageInfoContentService = softwareCategoryLanguageInfoContentService;
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

            SoftwareCategory model = null;
            if (Id != null)
            {
                model = await _service.GetByIdAsync(Int32.Parse(Id));
                model.SoftwareCategoryLanguageInfos = await _softwareCategoryLanguageInfo
                    .Where(x => x.SoftwareCategoryId == model.Id)
                    .Include(x => x.SoftwareCategoryLanguageInfoContents)
                    .ToListAsync();
            }

            //log işleme alanı     
            LogContext.PushProperty("TypeName", "List");
            _logger.LogCritical(functions.LogCriticalMessage("List", ControllerContext.ActionDescriptor.ControllerName, Id));

            return View(new SoftwareCategoryAddViewModel { MenuPermission = menuPermission, SoftwareCategory = model, Languages = await _languageService.GetAllAsync() });
        }

        [HttpPost]
        public async Task<IActionResult> Add(SoftwareCategory model, IFormFile Image, IFormFile ContentImage)
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            SoftwareCategory existing = null;
            if (model.Id != 0)
            {
                existing = await _service.Where(b => b.Id == model.Id).AsNoTracking().FirstOrDefaultAsync();
            }

            // Resim Yükleme
            if (Image != null && Image.Length > 0)
            {
                model.Image = await functions.ImageUpload(Image, "Images/SoftwareCategory", Guid.NewGuid().ToString("N"));
            }
            else if (existing != null)
            {
                model.Image = existing.Image;
            }

            if (ContentImage != null && ContentImage.Length > 0)
            {
                model.ContentImage = await functions.ImageUpload(ContentImage, "Images/SoftwareCategory", Guid.NewGuid().ToString("N"));
            }
            else if (existing != null)
            {
                model.ContentImage = existing.ContentImage;
            }

            if(model.Video != null)
            {
                model.Video = functions.ConvertToEmbedUrl(model.Video);
            }

            SoftwareCategory isControl;
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


            return View(new SoftwareCategoryAddViewModel { MenuPermission = menuPermission, SoftwareCategory = model, Languages = await _languageService.GetAllAsync() });
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

            return View(new SoftwareCategoryListViewModel { MenuPermission = menuPermission, SoftwareCategoryLanguageInfos = await _softwareCategoryLanguageInfo.Where(x => x.Language.Code == langCode.ToString()).Include(x => x.SoftwareCategory).ToListAsync() });
        }

        public async Task<IActionResult> Detail(string Id = null)
        {
            if (Id != null)
            {
                var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
                var langCode = rqf.RequestCulture.Culture;
                return View(await _softwareCategoryLanguageInfo.Where(x => x.SoftwareCategory.Id == Int32.Parse(Id) && x.Language.Code == langCode.ToString()).Include(x => x.SoftwareCategory).FirstOrDefaultAsync());
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
                SoftwareCategory item = await _service.GetByIdAsync(Int32.Parse(Id));
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
        public async Task<ResultJson> SubUnitRecord(SoftwareCategoryLanguageInfoContent model)
        {
            ResultJson resultJson = new ResultJson { status = "error" };

            try
            {
                SoftwareCategoryLanguageInfoContent isControl;
                if (model.Id != 0)
                {
                    // Güncelleme işlemi
                    isControl = await _softwareCategoryLanguageInfoContentService.UpdateAsync(model);
                  
                }
                else
                {
                    isControl = await _softwareCategoryLanguageInfoContentService.AddAsync(model);
                }

                // Veritabanı değişikliklerini kaydetme
                if (isControl.Id != 0)
                {
                    resultJson.status = "success";
                }
                else
                {
                    resultJson.message = "Bir hata oluştu.";
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
            var subUnits = await _softwareCategoryLanguageInfoContentService
                .Where(x => x.Sequence > 0)
                .Include(x => x.SoftwareCategoryLanguageInfo.SoftwareCategory)
                .Where(x => x.SoftwareCategoryLanguageInfo.SoftwareCategoryId == id)
                .ToListAsync();

            var viewModel = new SoftwareCategoryLanguageInfoContentSubUnitViewModel
            {
                SoftwareCategoryLanguageInfoContents = subUnits
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ResultJson> SubUnitDelete(int id)
        {
            ResultJson resultJson = new ResultJson { status = "error" };

            try
            {
                var item = await _softwareCategoryLanguageInfoContentService.GetByIdAsync(id);
                if (item != null)
                {
                    await _softwareCategoryLanguageInfoContentService.RemoveAsync(item);
                    resultJson.status = "success";
                  
                }
                else
                {
                    resultJson.message = "Silinecek kayıt bulunamadı.";
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
