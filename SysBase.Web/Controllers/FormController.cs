using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;
using SysBase.Core.Models;
using SysBase.Core.Services;
using SysBase.Service.Functions;
using SysBase.Web.Resources;
using SysBase.Web.ViewModels;
using System.Diagnostics;
using System.Globalization;

namespace SysBase.Web.Controllers
{
    public class FormController : BaseController
    {
        private readonly ILogger<FormController> _logger;
        protected readonly IService<SiteMenu> _siteMenuService;
        protected readonly IService<FooterMenu> _footerMenuService;
        protected readonly IService<Language> _languageService;
        protected readonly IService<QuickMenu> _quickMenuService;
        protected readonly IService<ProjectProduct> _projectProductService;
        protected readonly IService<ProjectField> _projectFieldService;
        protected Functions functions = new Functions();

        public FormController(IHtmlLocalizer<SharedResource> localizer, IService<Config> service,
           ILogger<FormController> logger, IService<SiteMenu> siteMenuService, IService<FooterMenu> footerMenuService,
           IService<Language> languageService, IService<QuickMenu> quickMenuService, IService<ProjectProduct> projectProductService, IService<ProjectField> projectFieldService)
          : base(localizer, service)
        {
            _logger = logger;
            _siteMenuService = siteMenuService;
            _footerMenuService = footerMenuService;
            _languageService = languageService;
            _quickMenuService = quickMenuService;
            _projectProductService = projectProductService;
            _projectFieldService = projectFieldService;
        }

        public async Task<IActionResult> Index(string slug)
        {
            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var langCode = rqf.RequestCulture.Culture;
            Debug.WriteLine(langCode);

            UiLayoutViewModel uiLayoutViewModel = new UiLayoutViewModel();
            uiLayoutViewModel.Config = _service.Where(x => x.Id == 1).FirstOrDefault();
            uiLayoutViewModel.SiteMenus = _siteMenuService.Where(x => x.Status && x.Language.Code == CultureInfo.CurrentCulture.Name).OrderBy(x => x.Sequence).ToList();
            uiLayoutViewModel.FooterMenus = _footerMenuService.Where(x => x.Status && x.Language.Code == CultureInfo.CurrentCulture.Name).OrderBy(x => x.Sequence).ToList();
            uiLayoutViewModel.Languages = _languageService.Where(x => x.Status).ToList();
            uiLayoutViewModel.QuickMenus = _quickMenuService.Where(x => x.Status && x.Language.Code == CultureInfo.CurrentCulture.Name).OrderBy(x => x.Sequence).ToList();

            List<ProjectProduct> projectProducts = new List<ProjectProduct>();
            if (slug != null && slug != "")
            {
                if (slug.EndsWith("-Y"))
                {
                    string code = slug.Split('-')[0];
                    projectProducts = await _projectProductService
                        .Where(x => x.Project.Code == slug && x.Project.Status && x.Product.Status && x.Product.Type == 2)
                        .Include(x => x.Project)
                        .ThenInclude(x => x.Company)
                        .Include(x => x.Product)
                        .ThenInclude(x => x.ProductLanguageInfos.Where(lng => lng.Language.Code == CultureInfo.CurrentCulture.Name))
                        .ToListAsync();
                }
                else
                {
                    string code = slug.Split('-')[0];
                    projectProducts = await _projectProductService
                        .Where(x => x.Project.Code == slug && x.Project.Status && x.Product.Status && x.Product.Type == 1)
                        .Include(x => x.Project)
                        .ThenInclude(x => x.Company)
                        .Include(x => x.Product)
                        .ThenInclude(x => x.ProductLanguageInfos.Where(lng => lng.Language.Code == CultureInfo.CurrentCulture.Name))
                        .ToListAsync();
                }
            }
            else
            {
                projectProducts = await _projectProductService
                    .Where(x => x.Project.Id == 1 && x.Project.Status && x.Product.Status)
                    .Include(x => x.Project)
                    .ThenInclude(x => x.Company)
                    .Include(x => x.Product)
                    .ThenInclude(x => x.ProductLanguageInfos.Where(lng => lng.Language.Code == CultureInfo.CurrentCulture.Name))
                    .ToListAsync();
            }

            List<ProjectField> projectFields = new List<ProjectField>();
            projectFields = await _projectFieldService.Where(x => x.ProjectId == projectProducts[0].ProjectId && x.Visible).Include(x=>x.Field).OrderBy(x => x.Field.Sequence).ToListAsync();

            FormViewModel model = new FormViewModel
            {
                Config = uiLayoutViewModel.Config,
                SiteMenus = uiLayoutViewModel.SiteMenus,
                FooterMenus = uiLayoutViewModel.FooterMenus,
                Languages = uiLayoutViewModel.Languages,
                QuickMenus = uiLayoutViewModel.QuickMenus,
                ProjectProducts = projectProducts,
                ProjectFields = projectFields,
            };

            return View(model);
        }
    }
}
