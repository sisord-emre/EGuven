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
    public class SectoralReferenceController : BaseController
    {
        private readonly ILogger<SectoralReferenceController> _logger;
        protected readonly IService<SiteMenu> _siteMenuService;
        protected readonly IService<FooterMenu> _footerMenuService;
        protected readonly IService<Language> _languageService;
        protected readonly IService<QuickMenu> _quickMenuService;
        protected readonly IService<SectoralReference> _sectoralReferenceService;
        protected readonly IService<SectorLanguageInfo> _sectorLanguageInfoService;

        public SectoralReferenceController(IHtmlLocalizer<SharedResource> localizer, IService<Config> service,
            ILogger<SectoralReferenceController> logger, IService<SiteMenu> siteMenuService, IService<FooterMenu> footerMenuService,
            IService<Language> languageService, IService<QuickMenu> quickMenuService, IService<SectoralReference> sectoralReferenceService,
            IService<SectorLanguageInfo> sectorLanguageInfoService)
           : base(localizer, service)
        {
            _logger = logger;
            _siteMenuService = siteMenuService;
            _footerMenuService = footerMenuService;
            _languageService = languageService;
            _quickMenuService = quickMenuService;
            _sectoralReferenceService = sectoralReferenceService;
            _sectorLanguageInfoService = sectorLanguageInfoService;
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

          
            // SectoralReferenceViewModel'i oluşturuyoruz
            SectoralReferenceViewModel model = new SectoralReferenceViewModel
            {
                Config = uiLayoutViewModel.Config,
                SiteMenus = uiLayoutViewModel.SiteMenus,
                FooterMenus = uiLayoutViewModel.FooterMenus,
                Languages = uiLayoutViewModel.Languages,
                QuickMenus = uiLayoutViewModel.QuickMenus,
                SectoralReferences = await _sectoralReferenceService.Where(x => x.Status).Include(sr => sr.SectoralReferenceSectors).ThenInclude(srs => srs.Sector).ToListAsync(),
                SectorLanguageInfos = await _sectorLanguageInfoService.Where(x => x.Language.Code == CultureInfo.CurrentCulture.Name && x.Status && x.Sector.Status).Include(x => x.Sector).OrderBy(x => x.Sector.Sequence).ToListAsync()
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
