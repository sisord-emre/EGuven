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
    public class PageDetailController : BaseController
    {
        private readonly ILogger<PageDetailController> _logger;
        protected readonly IService<SiteMenu> _siteMenuService;
        protected readonly IService<FooterMenu> _footerMenuService;
        protected readonly IService<Language> _languageService;
        protected readonly IService<QuickMenu> _quickMenuService;
        protected readonly IService<PageLanguageInfo> _PageLanguageInfoService;

        public PageDetailController(IHtmlLocalizer<SharedResource> localizer, IService<Config> service,
            ILogger<PageDetailController> logger, IService<SiteMenu> siteMenuService, IService<FooterMenu> footerMenuService,
            IService<QuickMenu> quickMenuService, IService<Language> languageService, IService<PageLanguageInfo> PageLanguageInfoService)
           : base(localizer, service)
        {
            _logger = logger;
            _siteMenuService = siteMenuService;
            _footerMenuService = footerMenuService;
            _quickMenuService = quickMenuService;
            _languageService = languageService;
            _PageLanguageInfoService = PageLanguageInfoService;
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

            // PageLanguageInfo öğesini önce bir değişkene atayın
            PageLanguageInfo PageLanguageInfo = await _PageLanguageInfoService
                .Where(x => x.Status && x.Slug == Slug && x.Language.Code == CultureInfo.CurrentCulture.Name && x.Status && x.Page.Status)
                .FirstOrDefaultAsync();

            PageDetailViewModel model = new PageDetailViewModel
            {
                Config = uiLayoutViewModel.Config,
                SiteMenus = uiLayoutViewModel.SiteMenus,
                FooterMenus = uiLayoutViewModel.FooterMenus,
                Languages = uiLayoutViewModel.Languages,
                QuickMenus = uiLayoutViewModel.QuickMenus,
                PageLanguageInfo = PageLanguageInfo,
            };

            return View(model);
        }
    }
}
