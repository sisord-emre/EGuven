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
    public class SoftwareCategoryDetailController : BaseController
    {
        protected readonly ILogger<SoftwareCategoryDetailController> _logger;
        protected readonly IService<SiteMenu> _siteMenuService;
        protected readonly IService<FooterMenu> _footerMenuService;
        protected readonly IService<Language> _languageService;
        protected readonly IService<QuickMenu> _quickMenuService;
        protected readonly IService<SoftwareCategoryLanguageInfo> _softwareCategoryLanguageInfoService;

        public SoftwareCategoryDetailController(IHtmlLocalizer<SharedResource> localizer, IService<Config> service,
            ILogger<SoftwareCategoryDetailController> logger, IService<SiteMenu> siteMenuService, IService<FooterMenu> footerMenuService,
            IService<QuickMenu> quickMenuService, IService<Language> languageService, IService<SoftwareCategoryLanguageInfo> softwareCategoryLanguageInfoService)
           : base(localizer, service)
        {
            _logger = logger;
            _siteMenuService = siteMenuService;
            _footerMenuService = footerMenuService;
            _quickMenuService = quickMenuService;
            _languageService = languageService;
            _softwareCategoryLanguageInfoService = softwareCategoryLanguageInfoService;
        }

        public async Task<IActionResult> Index(string Slug)
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

            SoftwareCategoryDetailViewModel model = new SoftwareCategoryDetailViewModel
            {
                Config = uiLayoutViewModel.Config,
                SiteMenus = uiLayoutViewModel.SiteMenus,
                FooterMenus = uiLayoutViewModel.FooterMenus,
                Languages = uiLayoutViewModel.Languages,
                QuickMenus = uiLayoutViewModel.QuickMenus,
                SoftwareCategoryLanguageInfo = await _softwareCategoryLanguageInfoService
                    .Where(x => x.Language.Code == langCode.ToString() && x.Status && x.SoftwareCategory.Status && x.SoftwareCategory.ScreenShow)
                    .Include(x => x.SoftwareCategory)
                    .Include(x => x.SoftwareCategoryLanguageInfoContents)
                    .FirstOrDefaultAsync(),

                SoftwareCategoryLanguageInfos = await _softwareCategoryLanguageInfoService
                    .Where(x => x.Language.Code == langCode.ToString() && x.Status && x.SoftwareCategory.Status && x.SoftwareCategory.ScreenShow)
                    .Include(x => x.SoftwareCategory)
                    .Include(x => x.SoftwareCategoryLanguageInfoContents)
                    .ToListAsync()
            };

            return View(model);
        }
    }
}
