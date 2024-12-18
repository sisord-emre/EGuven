using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.InkML;
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
    public class BlogDetailController : BaseController
    {
        private readonly ILogger<BlogDetailController> _logger;
        protected readonly IService<SiteMenu> _siteMenuService;
        protected readonly IService<FooterMenu> _footerMenuService;
        protected readonly IService<Language> _languageService;
        protected readonly IService<QuickMenu> _quickMenuService;
        protected readonly IService<BlogLanguageInfo> _blogLanguageInfoService;

        public BlogDetailController(IHtmlLocalizer<SharedResource> localizer, IService<Config> service,
            ILogger<BlogDetailController> logger, IService<SiteMenu> siteMenuService, IService<FooterMenu> footerMenuService,
            IService<QuickMenu> quickMenuService, IService<Language> languageService, IService<BlogLanguageInfo> blogLanguageInfoService)
           : base(localizer, service)
        {
            _logger = logger;
            _siteMenuService = siteMenuService;
            _footerMenuService = footerMenuService;
            _quickMenuService = quickMenuService;
            _languageService = languageService;
            _blogLanguageInfoService = blogLanguageInfoService;
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

            // BlogLanguageInfo öğesini önce bir değişkene atayın
            var blogLanguageInfo = await _blogLanguageInfoService
                .Where(x => x.Status && x.Slug == Slug && x.Language.Code == CultureInfo.CurrentCulture.Name && x.Status && x.Blog.Status)
                .FirstOrDefaultAsync();

            var lastPosts = await _blogLanguageInfoService.
                    Where(x => x.Language.Code == CultureInfo.CurrentCulture.Name && x.Status && x.Blog.Status).
                    Include(x => x.Blog).
                    OrderByDescending(x => x.Blog.Id).
                    Take(3).
                    ToListAsync();

            var beforeBlog = blogLanguageInfo != null
                    ? await _blogLanguageInfoService
                        .Where(x => x.Id < blogLanguageInfo.Id && x.Language.Code == CultureInfo.CurrentCulture.Name && x.Status && x.Blog.Status)
                        .OrderByDescending(x => x.Id)
                        .FirstOrDefaultAsync()
                    : null;

            var lastBlog = blogLanguageInfo != null
                    ? await _blogLanguageInfoService
                        .Where(x => x.Id > blogLanguageInfo.Id && x.Language.Code == CultureInfo.CurrentCulture.Name && x.Status && x.Blog.Status)
                        .OrderBy(x => x.Id)
                        .FirstOrDefaultAsync()
                    : null;

            BlogDetailViewModel model = new BlogDetailViewModel
            {
                Config = uiLayoutViewModel.Config,
                SiteMenus = uiLayoutViewModel.SiteMenus,
                FooterMenus = uiLayoutViewModel.FooterMenus,
                Languages = uiLayoutViewModel.Languages,
                QuickMenus = uiLayoutViewModel.QuickMenus,
                BlogLanguageInfo = blogLanguageInfo,
                LastPosts = lastPosts,
                BeforeBlog = beforeBlog,
                LastBlog = lastBlog
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