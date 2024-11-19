using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;
using SysBase.Core.Models;
using SysBase.Core.Services;
using SysBase.Web.Resources;
using SysBase.Web.ViewModels;
using System.Diagnostics;
using System.Globalization;

namespace SysBase.Web.Controllers
{
    public class SoftwareController : BaseController
    {
        private readonly ILogger<SoftwareController> _logger;
        protected readonly IService<SiteMenu> _siteMenuService;
        protected readonly IService<FooterMenu> _footerMenuService;
        protected readonly IService<Language> _languageService;
        protected readonly IService<QuickMenu> _quickMenuService;
        protected readonly IService<SoftwareLanguageInfo> _softwareLanguageInfoService;
        protected readonly IService<SoftwareCategoryLanguageInfo> _softwareCategoryLanguageInfoService;

        public SoftwareController(IHtmlLocalizer<SharedResource> localizer, IService<Config> service,
            ILogger<SoftwareController> logger, IService<SiteMenu> siteMenuService, IService<FooterMenu> footerMenuService,
            IService<QuickMenu> quickMenuService, IService<Language> languageService, IService<SoftwareLanguageInfo> softwareLanguageInfoService, IService<SoftwareCategoryLanguageInfo> softwareCategoryLanguageInfoService)
           : base(localizer, service)
        {
            _logger = logger;
            _siteMenuService = siteMenuService;
            _footerMenuService = footerMenuService;
            _quickMenuService = quickMenuService;
            _languageService = languageService;
            _softwareLanguageInfoService = softwareLanguageInfoService;
            _softwareCategoryLanguageInfoService = softwareCategoryLanguageInfoService;
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
            SoftwareCategoryLanguageInfo softwareCategoryLanguageInfo = _softwareCategoryLanguageInfoService.Where(x => x.Slug == slug).FirstOrDefault();

            SoftwareViewModel model = new SoftwareViewModel
            {
                Config = uiLayoutViewModel.Config,
                SiteMenus = uiLayoutViewModel.SiteMenus,
                FooterMenus = uiLayoutViewModel.FooterMenus,
                Languages = uiLayoutViewModel.Languages,
                QuickMenus = uiLayoutViewModel.QuickMenus,
                SoftwareLanguageInfos = await _softwareLanguageInfoService
                .Where(x => x.Language.Code == CultureInfo.CurrentCulture.Name && x.Status && x.Software.Status)
                .Include(x => x.Software)
                .ThenInclude(x => x.SoftwareCategory)
                .Where(x => x.Software.SoftwareCategoryId == softwareCategoryLanguageInfo.SoftwareCategoryId)
                .OrderBy(x => x.Software.Sequence)
                .ToListAsync(),
            };

            return View(model);
        }
    }
}
