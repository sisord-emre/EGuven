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
        protected readonly IService<City> _cityService;
        protected readonly IService<County> _countyService;
        protected Functions functions = new Functions();

        public FormController(IHtmlLocalizer<SharedResource> localizer, IService<Config> service,
           ILogger<FormController> logger, IService<SiteMenu> siteMenuService, IService<FooterMenu> footerMenuService,
           IService<Language> languageService, IService<QuickMenu> quickMenuService, IService<ProjectProduct> projectProductService, IService<ProjectField> projectFieldService, IService<City> cityService, IService<County> countyService)
          : base(localizer, service)
        {
            _logger = logger;
            _siteMenuService = siteMenuService;
            _footerMenuService = footerMenuService;
            _languageService = languageService;
            _quickMenuService = quickMenuService;
            _projectProductService = projectProductService;
            _projectFieldService = projectFieldService;
            _cityService = cityService;
            _countyService = countyService;
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
            projectFields = await _projectFieldService.Where(x => x.ProjectId == projectProducts[0].ProjectId && x.Visible).Include(x => x.Field).OrderBy(x => x.Field.Sequence).ToListAsync();

            FormViewModel model = new FormViewModel
            {
                Config = uiLayoutViewModel.Config,
                SiteMenus = uiLayoutViewModel.SiteMenus,
                FooterMenus = uiLayoutViewModel.FooterMenus,
                Languages = uiLayoutViewModel.Languages,
                QuickMenus = uiLayoutViewModel.QuickMenus,
                ProjectProducts = projectProducts,
                ProjectFields = projectFields,
                Cities = await _cityService.Where(x => x.CountryId == 2).OrderBy(x=>x.Name).ToListAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<String> IlIlce(int il)
        {
            string selectOptionList = "<option>" + _localizer["admin.Seçiniz"].Value + "</option>";
            foreach (County item in await _countyService.Where(x => x.CityId == il).OrderBy(x => x.Name).ToListAsync())
            {
                selectOptionList += "<option value='" + item.Id + "'>" + item.Name + "</option>";
            }
            return selectOptionList;
        }

        [HttpPost]
        public async Task<IActionResult> SepetList(string UrunList)
        {
            int[] urunArray = UrunList.Split(',').Select(int.Parse).ToArray();

            List<ProjectProduct> projectProducts = await _projectProductService
                .Where(x => urunArray.Contains(x.Id) && x.Project.Status && x.Product.Status)
                .Include(x => x.Product)
                .ThenInclude(x => x.ProductLanguageInfos)
                .ToListAsync();

            return View(projectProducts);
        }

    }
}
