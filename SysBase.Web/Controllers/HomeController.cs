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
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        protected readonly IService<SiteMenu> _siteMenuService;
        protected readonly IService<FooterMenu> _footerMenuService;
        protected readonly IService<Language> _languageService;
        protected readonly IService<Slider> _sliderService;
        protected readonly IService<QuickMenu> _quickMenuService;
        protected readonly IService<AnnouncementLanguageInfo> _announcementService;
        protected readonly IService<Brand> _brandService;
        protected readonly IService<BlogLanguageInfo> _blogLanguageInfoService;
        protected readonly IService<HelperVideoLanguageInfo> _helperVideoLanguageInfoService;
        protected readonly IService<HomeProductLanguageInfo> _homeProductLanguageInfoService;
        protected readonly IService<HomeTabPostLanguageInfo> _homeTabPostLanguageInfoService;

        public HomeController(IHtmlLocalizer<SharedResource> localizer, IService<Config> service,
            ILogger<HomeController> logger, IService<SiteMenu> siteMenuService, IService<FooterMenu> footerMenuService,
            IService<Language> languageService, IService<Slider> sliderService, IService<QuickMenu> quickMenuService,
            IService<AnnouncementLanguageInfo> announcementService, IService<Brand> brandService,
            IService<BlogLanguageInfo> blogLanguageInfoService, IService<HelperVideoLanguageInfo> helperVideoLanguageInfoService,
            IService<HomeProductLanguageInfo> homeProductLanguageInfoService, IService<HomeTabPostLanguageInfo> homeTabPostLanguageInfoService)
           : base(localizer, service)
        {
            _logger = logger;
            _siteMenuService = siteMenuService;
            _footerMenuService = footerMenuService;
            _languageService = languageService;
            _sliderService = sliderService;
            _quickMenuService = quickMenuService;
            _announcementService = announcementService;
            _brandService = brandService;
            _blogLanguageInfoService = blogLanguageInfoService;
            _helperVideoLanguageInfoService = helperVideoLanguageInfoService;
            _homeProductLanguageInfoService = homeProductLanguageInfoService;
            _homeTabPostLanguageInfoService = homeTabPostLanguageInfoService;
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

            /*
            IndexViewModel model = new IndexViewModel();
            model = (IndexViewModel)uiLayoutViewModel;
            model.Sliders = _sliderService.Where(x => x.Status && x.Language.Code == CultureInfo.CurrentCulture.Name).OrderBy(x => x).ToList();
            model.QuickMenus = _quickMenuService.Where(x => x.Status && x.Language.Code == CultureInfo.CurrentCulture.Name).OrderBy(x => x.Sequence).ToList();
            */
            IndexViewModel model = new IndexViewModel
            {
                Config = uiLayoutViewModel.Config,
                SiteMenus = uiLayoutViewModel.SiteMenus,
                FooterMenus = uiLayoutViewModel.FooterMenus,
                Languages = uiLayoutViewModel.Languages,
                QuickMenus = uiLayoutViewModel.QuickMenus,
                Sliders = _sliderService.Where(x => x.Status && x.Language.Code == CultureInfo.CurrentCulture.Name).OrderBy(x => x.Sequence).ToList(),
                Announcements = _announcementService
                    .Where(x => x.Status
                                && x.Language.Code == CultureInfo.CurrentCulture.Name
                                && x.Announcement.StartDate <= DateTime.Now
                                && x.Announcement.EndDate >= DateTime.Now)
                    .OrderBy(x => x.Announcement.Sequence)
                    .ToList(),
                Brands = _brandService.Where(x => x.Status).OrderBy(x => x.Sequence).Take(12).ToList(),
                BlogLanguageInfos = await _blogLanguageInfoService.Where(x => x.Language.Code == CultureInfo.CurrentCulture.Name && x.Blog.HomeVisibility).Include(x => x.Blog).OrderByDescending(x => x.Blog.Id).ToListAsync(),
                HelperVideoLanguageInfos = _helperVideoLanguageInfoService.Where(x => x.Language.Code == CultureInfo.CurrentCulture.Name && x.HelperVideo.HomeVisibility).Include(x => x.HelperVideo).ToList(),
                HelperVideoLanguageInfo = await _helperVideoLanguageInfoService.Where(x => x.Language.Code == CultureInfo.CurrentCulture.Name && x.HelperVideo.MasterVideo).Include(x => x.HelperVideo).FirstOrDefaultAsync(),
                HomeProductLanguageInfos = await _homeProductLanguageInfoService.Where(x => x.Language.Code == langCode.ToString()).Include(x => x.HomeProduct).ToListAsync(),
                HomeTabPostLanguageInfos = await _homeTabPostLanguageInfoService
                    .Where(x => x.Language.Code == langCode.ToString() && x.Status && x.HomeTabPost.Status)
                    .Include(x => x.HomeTabPost)
                    .Include(x => x.HomeTabPostLanguageInfoContents)
                    .ToListAsync()
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