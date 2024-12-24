using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SysBase.Core.Models;
using SysBase.Core.Services;
using SysBase.Service.Functions;
using SysBase.Web.Resources;
using SysBase.Web.ViewModels;
using System.Diagnostics;
using System.Globalization;
using System.Web.Helpers;

namespace SysBase.Web.Controllers
{
    public class ThanksController : BaseController
    {
        protected Functions functions = new Functions();
        private readonly ILogger<ThanksController> _logger;
        protected readonly IService<SiteMenu> _siteMenuService;
        protected readonly IService<FooterMenu> _footerMenuService;
        protected readonly IService<Language> _languageService;
        protected readonly IService<QuickMenu> _quickMenuService;
        protected readonly IService<ProjectProduct> _projectProductService;
        protected readonly IService<ProjectField> _projectFieldService;
        protected readonly IService<City> _cityService;
        protected readonly IService<County> _countyService;
        protected readonly IService<ApiBasvuruRequest> _apiBasvuruRequestService;

        public ThanksController(IHtmlLocalizer<SharedResource> localizer, IService<Config> service,
           ILogger<ThanksController> logger, IService<SiteMenu> siteMenuService, IService<FooterMenu> footerMenuService,
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
            UiLayoutViewModel uiLayoutViewModel = new UiLayoutViewModel();
            uiLayoutViewModel.Config = _service.Where(x => x.Id == 1).FirstOrDefault();
            uiLayoutViewModel.SiteMenus = _siteMenuService.Where(x => x.Status && x.Language.Code == CultureInfo.CurrentCulture.Name).OrderBy(x => x.Sequence).ToList();
            uiLayoutViewModel.FooterMenus = _footerMenuService.Where(x => x.Status && x.Language.Code == CultureInfo.CurrentCulture.Name).OrderBy(x => x.Sequence).ToList();
            uiLayoutViewModel.Languages = _languageService.Where(x => x.Status).ToList();
            uiLayoutViewModel.QuickMenus = _quickMenuService.Where(x => x.Status && x.Language.Code == CultureInfo.CurrentCulture.Name).OrderBy(x => x.Sequence).ToList();
            ApiBasvuruRequest apiBasvuruRequest = new ApiBasvuruRequest();

            if (slug == "" || slug == null)
            {
                Debug.WriteLine(Request.Form.Keys);
                Debug.WriteLine(Request.Form["procreturncode"]);
                if (Request.Form["procreturncode"] != "00")
                {
                    return Content("!!!!!" + Request.Form["mderrormessage"] + "!!!!!");
                }

                var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
                var langCode = rqf.RequestCulture.Culture;
                Debug.WriteLine(langCode);

                string Uid = Request.Form["orderid"];
                apiBasvuruRequest = await _apiBasvuruRequestService.Where(x => x.Uid == Uid).FirstOrDefaultAsync();
                apiBasvuruRequest.OdemeCevap = JsonConvert.SerializeObject(Request.Form);
                await _apiBasvuruRequestService.UpdateAsync(apiBasvuruRequest);
            }
            else
            {
                apiBasvuruRequest = await _apiBasvuruRequestService.Where(x => x.Uid == slug).FirstOrDefaultAsync();
            }

            ThanksViewModel thanksViewModel = new ThanksViewModel
            {
                Config = uiLayoutViewModel.Config,
                SiteMenus = uiLayoutViewModel.SiteMenus,
                FooterMenus = uiLayoutViewModel.FooterMenus,
                Languages = uiLayoutViewModel.Languages,
                QuickMenus = uiLayoutViewModel.QuickMenus,
                ApiBasvuruRequest = apiBasvuruRequest,
            };
            return View(thanksViewModel);
        }
    }
}
