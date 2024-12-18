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
using System.Diagnostics;
using System.Globalization;

namespace SysBase.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ProjectController : BaseController
    {
        // PageController specific dependencies
        protected readonly IService<Project> _service;
        protected readonly IService<Company> _companyService;
        protected readonly IService<CompanyInvoice> _companyInvoiceService;
        protected readonly IService<ProductLanguageInfo> _productLanguageInfosService;
        protected readonly IService<ProjectProduct> _projectProductService;
        protected readonly IService<FieldGroup> _fieldGroupService;
        protected readonly IService<ProjectField> _projectFieldService;
        protected readonly ILogger<ProjectController> _logger;

        public ProjectController(IHtmlLocalizer<SharedResource> localizer, UserManager<AppUser> userManager,
                              IService<Project> service, IService<Company> companyService, ILogger<ProjectController> logger, IService<CompanyInvoice> companyInvoiceService, IService<ProductLanguageInfo> productLanguageInfosService, IService<ProjectProduct> projectProductService, IService<FieldGroup> fieldGroupService, IService<ProjectField> projectFieldService)
            : base(localizer, userManager)
        {
            _service = service;
            _companyService = companyService;
            _logger = logger;
            _companyInvoiceService = companyInvoiceService;
            _productLanguageInfosService = productLanguageInfosService;
            _projectProductService = projectProductService;
            _fieldGroupService = fieldGroupService;
            _projectFieldService = projectFieldService;
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
            Project model = null;
            if (Id != null)
            {
                model = await _service.GetByIdAsync(Int32.Parse(Id));
            }

            //log işleme alanı     
            LogContext.PushProperty("TypeName", "List");
            _logger.LogCritical(functions.LogCriticalMessage("List", ControllerContext.ActionDescriptor.ControllerName, Id));

            List<ProjectProduct> projectProducts = new List<ProjectProduct>();
            if (Id != null)
            {
                projectProducts = await _projectProductService
                .Where(x => x.ProjectId == Convert.ToInt32(Id) && x.Product.ProductLanguageInfos.Any(x => x.Language.Code == CultureInfo.CurrentCulture.Name))
                .Include(x => x.Product)
                .ThenInclude(x => x.ProductLanguageInfos)
                .ToListAsync();
            }

            List<ProjectField> projectFields = new List<ProjectField>();
            if (Id != null)
            {
                projectFields = await _projectFieldService
                 .Where(x => x.ProjectId == Convert.ToInt32(Id))
                 .Include(x => x.Field)
                 .ToListAsync();
            }

            return View
            (
                new ProjectAddViewModel
                {
                    MenuPermission = menuPermission,
                    Project = model,
                    Companys = await _companyService.Where(x => x.Status).ToListAsync(),
                    CompanyInvoices = await _companyInvoiceService.Where(x => x.Status).ToListAsync(),
                    ProductLanguageInfos = await _productLanguageInfosService.Where(x => x.Status && x.Product.Status && x.Language.Code == CultureInfo.CurrentCulture.Name).Include(x => x.Product).OrderBy(x => x.Product.Sequence).ToListAsync(),
                    ProjectProducts = projectProducts,
                    FieldGroups = await _fieldGroupService.Where(x => x.Status).Include(x => x.Fields).ToListAsync(),
                    ProjectFields = projectFields,
                    Projects = await _service.Where(x => x.Status).Include(x => x.ProjectFields).ThenInclude(x => x.Field).ToListAsync(),
                }
            );
        }

        [HttpPost]
        public async Task<IActionResult> Add(Project model, IFormFile Image, List<ProductInfoViewModel> ProductInfos, List<ProjectFieldViewModel> ProjectFieldViewModels)
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            if (Image != null && Image.Length > 0)
            {
                model.Image = await functions.ImageUpload(Image, "Images/Project", Guid.NewGuid().ToString("N"));
            }
            else if (model.Id != 0)
            {
                var existing = await _service.Where(b => b.Id == model.Id).AsNoTracking().FirstOrDefaultAsync();
                model.Image = existing.Image;  // Eski resim tekrar set ediliyor
            }

            Project isControl;
            if (model.Id != 0)
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

            List<ProjectProduct> projectProductsDelList = await _projectProductService.Where(x => x.ProjectId == isControl.Id).ToListAsync();
            if (projectProductsDelList.Count > 0)
            {
                await _projectProductService.RemoveRangeAsync(projectProductsDelList);
            }
            List<ProjectProduct> projectProductList = new List<ProjectProduct>();
            foreach (ProductInfoViewModel productInfo in ProductInfos)
            {
                if (productInfo.Secim)
                {
                    ProjectProduct projectProduct = new ProjectProduct();
                    projectProduct.ProjectId = isControl.Id;
                    projectProduct.ProductId = productInfo.ProductId;
                    projectProduct.Amount = productInfo.Amount;
                    projectProductList.Add(projectProduct);
                }
            }
            await _projectProductService.AddRangeAsync(projectProductList);


            List<ProjectField> _projectFieldServiceDilList = await _projectFieldService.Where(x => x.ProjectId == isControl.Id).ToListAsync();
            if (_projectFieldServiceDilList.Count > 0)
            {
                await _projectFieldService.RemoveRangeAsync(_projectFieldServiceDilList);
            }
            List<ProjectField> projectFieldList = new List<ProjectField>();
            foreach (ProjectFieldViewModel productInfo in ProjectFieldViewModels)
            {
                ProjectField projectField = new ProjectField();
                projectField.ProjectId = isControl.Id;
                projectField.FieldId = productInfo.FieldId;
                projectField.Visible = productInfo.Visible;
                projectField.Required = productInfo.Required;
                projectFieldList.Add(projectField);
            }
            await _projectFieldService.AddRangeAsync(projectFieldList);


            List<ProjectProduct> projectProducts = new List<ProjectProduct>();
            if (isControl.Id != 0)
            {
                projectProducts = await _projectProductService
                 .Where(x => x.ProjectId == Convert.ToInt32(isControl.Id) && x.Product.ProductLanguageInfos.Any(x => x.Language.Code == CultureInfo.CurrentCulture.Name))
                 .Include(x => x.Product)
                 .ThenInclude(x => x.ProductLanguageInfos)
                 .ToListAsync();
            }

            List<ProjectField> projectFields = new List<ProjectField>();
            if (isControl.Id != 0)
            {
                projectFields = await _projectFieldService
                 .Where(x => x.ProjectId == Convert.ToInt32(isControl.Id))
                 .Include(x => x.Field)
                 .ToListAsync();
            }

            return View
            (
                new ProjectAddViewModel
                {
                    MenuPermission = menuPermission,
                    Project = model,
                    Companys = await _companyService.Where(x => x.Status).ToListAsync(),
                    CompanyInvoices = await _companyInvoiceService.Where(x => x.Status).ToListAsync(),
                    ProductLanguageInfos = await _productLanguageInfosService.Where(x => x.Status && x.Product.Status && x.Language.Code == CultureInfo.CurrentCulture.Name).Include(x => x.Product).OrderBy(x => x.Product.Sequence).ToListAsync(),
                    ProjectProducts = projectProducts,
                    FieldGroups = await _fieldGroupService.Where(x => x.Status).Include(x => x.Fields).ToListAsync(),
                    ProjectFields = projectFields,
                    Projects = await _service.Where(x => x.Status).Include(x => x.ProjectFields).ThenInclude(x => x.Field).ToListAsync(),
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

            //log işleme alanı
            LogContext.PushProperty("TypeName", ControllerContext.ActionDescriptor.ActionName);
            _logger.LogCritical(functions.LogCriticalMessage(ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName));

            return View
            (
                new ProjectListViewModel
                {
                    MenuPermission = menuPermission,
                    Projects = await _service.ToListAsync(),
                    Companys = await _companyService.Where(x => x.Status).ToListAsync()
                }
            );
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
                Project item = await _service.GetByIdAsync(Int32.Parse(Id));
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
        public async Task<String> CompanyInvoicesSelect(int id)
        {
            string selectOptionList = "<option>" + _localizer["admin.Seçiniz"].Value + "</option>";
            foreach (CompanyInvoice item in await _companyInvoiceService.Where(x => x.Status && x.CompanyId == id).ToListAsync())
            {
                selectOptionList += "<option value='" + item.Id + "'>" + item.Name + "</option>";
            }
            return selectOptionList;
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
