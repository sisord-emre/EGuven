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
    public class BlogListRowController : BaseController
    {
        private readonly ILogger<BlogListRowController> _logger;
        protected readonly IService<SiteMenu> _siteMenuService;
        protected readonly IService<FooterMenu> _footerMenuService;
        protected readonly IService<Language> _languageService;
        protected readonly IService<QuickMenu> _quickMenuService;
        protected readonly IService<BlogLanguageInfo> _blogLanguageInfoService;
        protected readonly IService<BlogType> _blogTypeService;

        public BlogListRowController(IHtmlLocalizer<SharedResource> localizer, IService<Config> service,
            ILogger<BlogListRowController> logger, IService<SiteMenu> siteMenuService, IService<FooterMenu> footerMenuService,
            IService<QuickMenu> quickMenuService, IService<Language> languageService, IService<BlogLanguageInfo> blogLanguageInfoService,
            IService<BlogType> blogTypeService)
           : base(localizer, service)
        {
            _logger = logger;
            _siteMenuService = siteMenuService;
            _footerMenuService = footerMenuService;
            _quickMenuService = quickMenuService;
            _languageService = languageService;
            _blogLanguageInfoService = blogLanguageInfoService;
            _blogTypeService = blogTypeService;
        }


        public async Task<IActionResult> Index(int page = 1, int pageSize = 4)
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


            // Sayfalama için toplam blog dil bilgilerini say
            var blogTypes = await _blogTypeService
               .Where(x => x.Language.Code == CultureInfo.CurrentCulture.Name)
               .ToListAsync();

            var totalBlogLanguageInfos = await _blogLanguageInfoService
                .Where(x => x.Language.Code == CultureInfo.CurrentCulture.Name)
                .CountAsync();

            // Sayfalama ile BlogLanguageInfos'u al
            var blogLanguageInfos = await _blogLanguageInfoService
                .Where(x => x.Language.Code == CultureInfo.CurrentCulture.Name)
                .Include(x => x.Blog)
                .OrderBy(x => x.Blog.Sequence)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Son blog yazılarını al
            var lastPosts = await _blogLanguageInfoService
                .Where(x => x.Language.Code == CultureInfo.CurrentCulture.Name)
                .Include(x => x.Blog)
                .OrderByDescending(x => x.Blog.Id)
                .Take(3)
                .ToListAsync();

            BlogViewModel model = new BlogViewModel
            {
                Config = uiLayoutViewModel.Config,
                SiteMenus = uiLayoutViewModel.SiteMenus,
                FooterMenus = uiLayoutViewModel.FooterMenus,
                Languages = uiLayoutViewModel.Languages,
                QuickMenus = uiLayoutViewModel.QuickMenus,
                BlogLanguageInfos = blogLanguageInfos,
                BlogTypes = blogTypes,
                LastPosts = lastPosts,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalBlogLanguageInfos / (double)pageSize)
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