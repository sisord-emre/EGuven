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
    public class SectoralReferenceController : BaseController
    {
        // SectoralReferenceController specific dependencies
        protected readonly IService<SectoralReference> _service;
        protected readonly IService<Sector> _sectorService;
        protected readonly IService<SectoralReferenceSector> _sectoralReferenceSectorService;
        protected readonly ILogger<SectoralReferenceController> _logger;

        public SectoralReferenceController(IHtmlLocalizer<SharedResource> localizer, UserManager<AppUser> userManager,
                IService<SectoralReference> service, IService<Sector> sectorService,
                IService<SectoralReferenceSector> sectoralReferenceSectorService,
                ILogger<SectoralReferenceController> logger)
            : base(localizer, userManager)
        {
            _service = service;
            _sectorService = sectorService;
            _sectoralReferenceSectorService = sectoralReferenceSectorService;
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

            // Şartlara göre kullanıcıları filtrele
            var appSectors = await _sectorService.Where(x => x.Status).Include(x => x.SectorLanguageInfos).ToListAsync();
            List<int> selectedSectorIds = null;
            SectoralReference model = null;
            if (Id != null)
            {
                model = await _service.GetByIdAsync(Int32.Parse(Id));
                model.SectoralReferenceSectors = await _sectoralReferenceSectorService
                    .Where(x => x.SectoralReferenceId == model.Id)
                    .ToListAsync();

                selectedSectorIds = await _sectoralReferenceSectorService
                    .Where(bk => bk.SectoralReferenceId == int.Parse(Id))
                    .Select(bk => bk.SectorId)
                    .ToListAsync();
            }

            // SectoralReferences ve max Sequence bulma
            var sectoralReferences = await _service.ToListAsync();

            var maxSequence = sectoralReferences
                .DefaultIfEmpty()
                .Max(x => x?.Sequence ?? 0);

            //log işleme alanı     
            LogContext.PushProperty("TypeName", "List");
            _logger.LogCritical(functions.LogCriticalMessage("List", ControllerContext.ActionDescriptor.ControllerName, Id));

            return View
            (
                new SectoralReferenceAddViewModel
                {
                    MenuPermission = menuPermission,
                    SectoralReference = model,
                    AppSectors = (List<Sector>)appSectors,
                    SelectedSectorIds = selectedSectorIds ?? new List<int>(),
                    MaxSequence = maxSequence
                }
            );
        }

        [HttpPost]
        public async Task<IActionResult> Add(SectoralReference model, int[] SectorIdValue, IFormFile Image)
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            if (Image != null && Image.Length > 0)
            {
                model.Media = await functions.ImageUpload(Image, "Images/SectoralReference", Guid.NewGuid().ToString("N"));
            }
            else if (model.Id != 0)
            {
                var existing = await _service.Where(b => b.Id == model.Id).AsNoTracking().FirstOrDefaultAsync();
                model.Media = existing.Media;  // Eski resim tekrar set ediliyor
            }

            SectoralReference isControl;
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
                // Mevcut SectoralReferenceSector kayıtlarını sil
                IEnumerable<SectoralReferenceSector> SectoralReferenceSectors = await _sectoralReferenceSectorService.Where(x => x.SectoralReferenceId == model.Id).ToListAsync();
                await _sectoralReferenceSectorService.RemoveRangeAsync(SectoralReferenceSectors);
                for (int i = 0; i < SectorIdValue.Length; i++)
                {
                    SectoralReferenceSector addItem = new SectoralReferenceSector();
                    addItem.SectoralReferenceId = isControl.Id;
                    addItem.SectorId = SectorIdValue[i];

                    await _sectoralReferenceSectorService.AddAsync(addItem);
                }

                TempData["SuccessMessage"] = _localizer["admin.Kayıt İşlemi Başarıyle Gerçekleşmiştir."].Value;
            }
            else
            {
                TempData["ErrorMessage"] = _localizer["admin.Bilgileri Kontrol Ediniz"].Value;
            }

            model.SectoralReferenceSectors = await _sectoralReferenceSectorService.Where(x => x.SectoralReferenceId == isControl.Id).ToListAsync();

            // Şartlara göre kullanıcıları filtrele
            var appSectors = await _sectorService.Where(x => x.Status).Include(x => x.SectorLanguageInfos).ToListAsync();
            List<int> selectedSectorIds = null;
            selectedSectorIds = await _sectoralReferenceSectorService
                    .Where(bk => bk.SectoralReferenceId == isControl.Id)
                    .Select(bk => bk.SectorId)
                    .ToListAsync();

            // SectoralReferences ve max Sequence bulma
            var sectoralReferences = await _service.ToListAsync();

            var maxSequence = sectoralReferences
                .DefaultIfEmpty()
                .Max(x => x?.Sequence ?? 0);

            return View
            (
                new SectoralReferenceAddViewModel
                {
                    MenuPermission = menuPermission,
                    SectoralReference = model,
                    AppSectors = (List<Sector>)appSectors,
                    SelectedSectorIds = selectedSectorIds ?? new List<int>(),
                    MaxSequence = maxSequence
                }
            );
        }

        public async Task<IActionResult> List()
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            // Şartlara göre kullanıcıları filtrele
            var appSectors = await _sectorService.Where(x => x.Status).Include(x => x.SectorLanguageInfos).ToListAsync();
            List<int> selectedSectorIds = null;
            selectedSectorIds = await _sectoralReferenceSectorService
                    .Where(bk => bk.Id > 0)
                    .Select(bk => bk.SectorId)
                    .ToListAsync();

            //log işleme alanı
            LogContext.PushProperty("TypeName", ControllerContext.ActionDescriptor.ActionName);
            _logger.LogCritical(functions.LogCriticalMessage(ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName));

            return View
            (
               new SectoralReferenceListViewModel
               {
                   MenuPermission = menuPermission,
                   SectoralReferences = await _service.Where(x => x.SectoralReferenceSectors.Any(nu => nu.SectoralReferenceId == x.Id)).Include(x => x.SectoralReferenceSectors).ToListAsync(),
                   AppSectors = (List<Sector>)appSectors,
                   SelectedSectorIds = selectedSectorIds ?? new List<int>()
               }
            );
        }

        public async Task<IActionResult> Detail(string Id = null)
        {
            if (Id != null)
            {
                // Şartlara göre kullanıcıları filtrele
                var appSectors = await _sectorService.Where(x => x.Status).Include(x => x.SectorLanguageInfos).ToListAsync();
                // Kullanıcı listesini ve seçili olanları ViewData ile gönder
                ViewData["appSectors"] = appSectors;
                return View(await _service.Where(x => x.Id == Int32.Parse(Id)).Include(x => x.SectoralReferenceSectors).FirstOrDefaultAsync());
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
                SectoralReference item = await _service.GetByIdAsync(Int32.Parse(Id));
                if (item != null)
                {
                    List<SectoralReferenceSector> deletedSectoralReferenceSector = await _sectoralReferenceSectorService.Where(x => x.SectoralReferenceId == item.Id).AsNoTracking().ToListAsync();
                    foreach (var item1 in deletedSectoralReferenceSector)
                    {
                        SectoralReferenceSector addItem = new SectoralReferenceSector
                        {
                            Id = item1.Id,
                            SectoralReferenceId = item1.SectoralReferenceId,
                            SectorId = item1.SectorId,
                        };
                        await _sectoralReferenceSectorService.UpdateAsync(addItem);
                    }

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
