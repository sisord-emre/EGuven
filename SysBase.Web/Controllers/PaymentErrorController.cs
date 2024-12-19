using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using SysBase.Core.Models;
using SysBase.Core.Services;
using SysBase.Service.Functions;
using SysBase.Web.Resources;

namespace SysBase.Web.Controllers
{
    public class PaymentErrorController : BaseController
    {
        protected Functions functions = new Functions();
        private readonly ILogger<PaymentErrorController> _logger;
        protected readonly IService<SiteMenu> _siteMenuService;
        protected readonly IService<FooterMenu> _footerMenuService;
        protected readonly IService<Language> _languageService;
        protected readonly IService<QuickMenu> _quickMenuService;
        protected readonly IService<ProjectProduct> _projectProductService;
        protected readonly IService<ProjectField> _projectFieldService;
        protected readonly IService<City> _cityService;
        protected readonly IService<County> _countyService;
        protected readonly IService<ApiBasvuruRequest> _apiBasvuruRequestService;

        public PaymentErrorController(IHtmlLocalizer<SharedResource> localizer, IService<Config> service,
           ILogger<PaymentErrorController> logger, IService<SiteMenu> siteMenuService, IService<FooterMenu> footerMenuService,
           IService<Language> languageService, IService<QuickMenu> quickMenuService, IService<ProjectProduct> projectProductService, IService<ProjectField> projectFieldService, IService<City> cityService, IService<County> countyService, IService<ApiBasvuruRequest> apiBasvuruRequestService)
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
            _apiBasvuruRequestService = apiBasvuruRequestService;
        }

        public async Task<IActionResult> Index(string slug)
        {

            return View();
        }
    }
}
