using DocumentFormat.OpenXml.Wordprocessing;
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
using SysBase.Web.Areas.Admin.Models;
using SysBase.Web.Resources;

namespace SysBase.Web.Areas.Admin.Controllers
{
    //[Authorize(Roles = "Administrator,Finance")]
    [Authorize]
    [Area("Admin")]
    public class PanelLanguageController : BaseController
    {
        // PanelLanguageController specific dependencies
        protected readonly ILanguageValueService _service;
        protected readonly IService<Language> _languageService;
        protected readonly IService<LanguageKey> _languageKeyService;
        protected readonly IService<LanguageValue> _languageValueService;
        protected readonly IService<Config> _configService;
        protected readonly ILogger<PanelLanguageController> _logger;

        public PanelLanguageController(IHtmlLocalizer<SharedResource> localizer, UserManager<AppUser> userManager,
                                  ILanguageValueService service, IService<Language> languageService,
                                  IService<LanguageKey> languageKeyService, IService<LanguageValue> languageValueService,
                                  IService<Config> configService, ILogger<PanelLanguageController> logger)
            : base(localizer, userManager)
        {
            _service = service;
            _languageService = languageService;
            _languageKeyService = languageKeyService;
            _languageValueService = languageValueService;
            _configService = configService;
            _logger = logger;
        }

        //[Authorize(Roles = "Finance")]
        public async Task<IActionResult> Add(string Id = null)
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            Language language = null;
            if (Id != null)
            {
                language = await _languageService.GetByIdAsync(Int32.Parse(Id));
            }

            IEnumerable<LanguageKey> languageKeys = null;
            if (Id != null)
            {
                languageKeys = await _languageKeyService
                    .Where(x => x.Type == 2)
                    .OrderByDescending(x => x.Id)
                    .ToListAsync();
            }

            IEnumerable<LanguageValue> languageValues = null;
            if (Id != null)
            {
                languageValues = await _languageValueService
                    .Where(x => x.LanguageId == language.Id)
                    .OrderByDescending(x => x.Id)
                    .ToListAsync();
            }

            //log işleme alanı     
            LogContext.PushProperty("TypeName", "List");
            _logger.LogCritical(functions.LogCriticalMessage("List", ControllerContext.ActionDescriptor.ControllerName, Id));

            return View(new LanguageAddViewModel { MenuPermission = menuPermission, Language = language, LanguageKeys = languageKeys, LanguageValues = languageValues });
        }

        [HttpPost]
        public async Task<IActionResult> Add(Language model, IFormFile Image)
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            if (Image != null && Image.Length > 0)
            {
                model.Image = await functions.ImageUpload(Image, "Images", model.Code);
            }
            else if (model.Id != 0)
            {
                var existing = await _languageService.Where(b => b.Id == model.Id).AsNoTracking().FirstOrDefaultAsync();
                model.Image = existing.Image;  // Eski resim tekrar set ediliyor
            }
            
            Language isControl;
            if (ModelState.IsValid)
            {
                isControl = await _languageService.UpdateAsync(model);

                //log işleme alanı
                LogContext.PushProperty("TypeName", "Update");
                _logger.LogCritical(functions.LogCriticalMessage("Update", ControllerContext.ActionDescriptor.ControllerName, isControl.Id.ToString(), JsonConvert.SerializeObject(model)));
            }
            else
            {
                isControl = await _languageService.AddAsync(model);

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

            IEnumerable<LanguageKey> languageKeys = null;
            if (isControl.Id != null)
            {
                languageKeys = await _languageKeyService
                    .Where(x => x.Type == 2)
                    .OrderByDescending(x => x.Id)
                    .ToListAsync();
            }

            IEnumerable<LanguageValue> languageValues = null;
            if (isControl.Id != null)
            {
                languageValues = await _languageValueService
                    .Where(x => x.LanguageId == isControl.Id)
                    .OrderByDescending(x => x.Id)
                    .ToListAsync();
            }

            return View(new LanguageAddViewModel { MenuPermission = menuPermission, Language = isControl, LanguageKeys = languageKeys, LanguageValues = languageValues });
        }

        public async Task<ResultJson> LanguageValueUpdate(int[] languageKeyId, int[] languageValueId, string[] Text, int languageId, string languageCode)
        {
            ResultJson resultJson = new ResultJson
            {
                status = "success",
                message = _localizer["admin.Güncelleme Başarılı"].Value
            };

            // Mevcut LanguageValue kayıtlarını sil
            // IEnumerable<LanguageValue> languageValues = await _languageValueService.Where(x => x.LanguageId == languageId).ToListAsync();
            // await _languageValueService.RemoveRangeAsync(languageValues);

            int sayac = 0;
            foreach (string item in Text)
            {
                // Her döngüde yeni bir LanguageValue instance'ı oluştur
                LanguageValue model = new LanguageValue
                {
                    LanguageId = languageId,
                    LanguageKeyId = languageKeyId[sayac],
                    Text = item
                };
                if(languageValueId[sayac] == 0)
                {
                    // Yeni modeli ekle
                    await _languageValueService.AddAsync(model);

                    //log işleme alanı
                    LogContext.PushProperty("TypeName", ControllerContext.ActionDescriptor.ActionName);
                    _logger.LogCritical(functions.LogCriticalMessage(ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName, model.Id.ToString(), JsonConvert.SerializeObject(model)));
                }
                else
                {
                    // Yeni modeli ekle
                    model.Id = languageValueId[sayac];
                    await _languageValueService.UpdateAsync(model);

                    //log işleme alanı
                    LogContext.PushProperty("TypeName", "Update");
                    _logger.LogCritical(functions.LogCriticalMessage("Update", ControllerContext.ActionDescriptor.ControllerName, model.Id.ToString(), JsonConvert.SerializeObject(model)));
                }
                sayac++;
            }

            // LanguageSetAsync methodunu çağır
            await LanguageSetAsync(languageCode, 2, "Resources/");

            return resultJson;
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

            return View(new LanguageListViewModel { MenuPermission = menuPermission, Languages = await _languageService.GetAllAsync() });
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
                Language item = await _languageService.GetByIdAsync(Int32.Parse(Id));
                if (item != null)
                {
                    await _languageService.RemoveAsync(item);
                    resultJson.status = "success";
                    return resultJson;
                }
            }

            //log işleme alanı
            LogContext.PushProperty("TypeName", ControllerContext.ActionDescriptor.ActionName);
            _logger.LogCritical(functions.LogCriticalMessage(ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName, Id));

            return resultJson;
        }

        public async Task<IActionResult> KeyList(string Id = null)
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, "Language");
            if (!functions.MenuPermControl(menuPermission, "List"))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            LanguageKey languageKey = null;
            if (Id != null)
            {
                languageKey = await _languageKeyService.GetByIdAsync(Int32.Parse(Id));
            }

            //log işleme alanı
            LogContext.PushProperty("TypeName", ControllerContext.ActionDescriptor.ActionName);
            _logger.LogCritical(functions.LogCriticalMessage(ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName, Id));

            return View(new LanguageKeyListViewModel { MenuPermission = menuPermission, LanguageKeys = await _languageKeyService.Where(x => x.Type == 2).ToListAsync(), LanguageKey = languageKey });
        }

        [HttpPost]
        public async Task<IActionResult> KeyAdd(LanguageKey model)
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, "Language");
            if (!functions.MenuPermControl(menuPermission, "List"))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            var existingConfig = await _configService.GetByIdAsync(1);

            model.Type = 2;
            LanguageKey isControl;
            if (ModelState.IsValid)
            {
                isControl = await _languageKeyService.UpdateAsync(model);

                //log işleme alanı
                LogContext.PushProperty("TypeName", "Update");
                _logger.LogCritical(functions.LogCriticalMessage("Update", ControllerContext.ActionDescriptor.ControllerName, isControl.Id.ToString(), JsonConvert.SerializeObject(model)));
            }
            else
            {
                isControl = await _languageKeyService.AddAsync(model);

                //log işleme alanı
                LogContext.PushProperty("TypeName", ControllerContext.ActionDescriptor.ActionName);
                _logger.LogCritical(functions.LogCriticalMessage(ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName, isControl.Id.ToString(), JsonConvert.SerializeObject(model)));
            }
            if (isControl.Id != 0)
            {
                LanguageValue languageValue = new LanguageValue();
                languageValue.LanguageId = existingConfig.AdminLanguageId;
                languageValue.LanguageKeyId = isControl.Id;
                languageValue.Text = model.Code.StartsWith("admin.") ? model.Code.Substring(6) : model.Code;
                await _languageValueService.AddAsync(languageValue);
             
                TempData["SuccessMessage"] = _localizer["admin.Kayıt İşlemi Başarıyle Gerçekleşmiştir."].Value;
            }
            else
            {
                TempData["ErrorMessage"] = _localizer["admin.Bilgileri Kontrol Ediniz"].Value;
            }

            return View("KeyList", new LanguageKeyListViewModel { MenuPermission = menuPermission, LanguageKeys = await _languageKeyService.Where(x => x.Type == 2).ToListAsync() });
        }

        public async Task<ResultJson> KeyDelete(string Id = null)
        {
            ResultJson resultJson = new ResultJson();
            resultJson.status = "error";
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, "Language");
            if (!functions.MenuPermControl(menuPermission, "Delete"))
            {
                resultJson.message = _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value;
                return resultJson;
            }

            if (Id != null)
            {
                LanguageKey item = await _languageKeyService.GetByIdAsync(Int32.Parse(Id));
                if (item != null)
                {
                    await _languageKeyService.RemoveAsync(item);
                    resultJson.status = "success";
                    return resultJson;
                }
            }

            //log işleme alanı
            LogContext.PushProperty("TypeName", ControllerContext.ActionDescriptor.ActionName);
            _logger.LogCritical(functions.LogCriticalMessage(ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName, Id));

            return resultJson;
        }

        //await LanguageSetAsync("tr", 0, "Resources/");
        protected async Task LanguageSetAsync(String languageCode, int type, String path)//type=>0:Her İkisi,1:Site,2:Admin
        {
            List<LanguageValuesWithLanguageKeyDto> languageValuesWithLanguageKeyDtos = await _service.GetLanguageValuesWithLanguageKey(languageCode, type);
            if (languageCode == "en")
            {
                languageCode = "SharedResource";
            }
            else
            {
                languageCode = "SharedResource." + languageCode;
            }
            path = path.Replace("/", "\\");
            string resxFile = Path.Combine(Directory.GetCurrentDirectory(), @path + languageCode + ".resx");
            // ResXResourceWriter nesnesi oluşturuluyor
            using (ResXResourceWriter resxWriter = new ResXResourceWriter(resxFile))
            {
                foreach (LanguageValuesWithLanguageKeyDto item in languageValuesWithLanguageKeyDtos.OrderBy(x=>x.Id))
                {
                    // Veriler ekleniyor
                    resxWriter.AddResource(item.LanguageKey.Code, item.Text);
                }
                if (languageValuesWithLanguageKeyDtos.Count > 0)
                {
                    // ResXResourceWriter'ı temizleyip kapatıyor
                    resxWriter.Generate();
                }
            }
        }
    }
}
