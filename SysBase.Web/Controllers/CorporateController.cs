using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;
using SysBase.Core.Models;
using SysBase.Core.Services;
using SysBase.Web.Models;
using SysBase.Web.Resources;
using SysBase.Web.ViewModels;
using System.Diagnostics;
using System.Globalization;

namespace SysBase.Web.Controllers
{
    public class CorporateController : BaseController
    {
        private readonly ILogger<CorporateController> _logger;
        protected readonly IService<SiteMenu> _siteMenuService;
        protected readonly IService<FooterMenu> _footerMenuService;
        protected readonly IService<Language> _languageService;
        protected readonly IService<QuickMenu> _quickMenuService;
        protected readonly IService<Corporate> _corporateService;

        public CorporateController(IHtmlLocalizer<SharedResource> localizer, IService<Config> service,
            ILogger<CorporateController> logger, IService<SiteMenu> siteMenuService, IService<FooterMenu> footerMenuService, 
            IService<Language> languageService, IService<QuickMenu> quickMenuService, IService<Corporate> corporateService)
           : base(localizer, service)
        {
            _logger = logger;
            _siteMenuService = siteMenuService;
            _footerMenuService = footerMenuService;
            _languageService = languageService;
            _quickMenuService = quickMenuService;
            _corporateService = corporateService;
        }


        public async Task<IActionResult> Index()
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

            // Corporate ve ilişkili CorporateLanguageInfo verilerini getiriyoruz
            var corporate = await _corporateService
                .Where(x => x.CorporateLanguageInfos.Any(cl => cl.Language.Code == CultureInfo.CurrentCulture.Name && x.Status))
                .Include(x => x.CorporateLanguageInfos.Where(cl => cl.Language.Code == CultureInfo.CurrentCulture.Name))
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();

            // CorporateViewModel'i oluşturuyoruz
            CorporateViewModel model = new CorporateViewModel
            {
                Config = uiLayoutViewModel.Config,
                SiteMenus = uiLayoutViewModel.SiteMenus,
                FooterMenus = uiLayoutViewModel.FooterMenus,
                Languages = uiLayoutViewModel.Languages,
                QuickMenus = uiLayoutViewModel.QuickMenus,
                Corporate = await _corporateService
                    .Where(x => x.CorporateLanguageInfos.Any(cl => cl.Language.Code == CultureInfo.CurrentCulture.Name && x.Status))
                    .Include(x => x.CorporateLanguageInfos.Where(cl => cl.Language.Code == CultureInfo.CurrentCulture.Name))
                    .OrderByDescending(x => x.Id)
                    .FirstOrDefaultAsync()
            };

            return View(model);
        }


        public IActionResult SetLang(string lng, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(lng)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
            return LocalRedirect(returnUrl);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
