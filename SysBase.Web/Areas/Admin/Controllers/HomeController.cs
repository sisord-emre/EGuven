using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;
using Serilog.Context;
using SysBase.Core.Models;
using SysBase.Core.Services;
using SysBase.Web.Areas.Admin.Models;
using SysBase.Web.Resources;
using System.Diagnostics;


namespace SysBase.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class HomeController : BaseController
    {
        // HomeController specific dependencies
        protected readonly IService<Language> _languageService;
        protected readonly IService<Config> _service;
        protected readonly SignInManager<AppUser> _signInManager;
        protected readonly ILogger<HomeController> _logger;

        public HomeController(IHtmlLocalizer<SharedResource> localizer, UserManager<AppUser> userManager,
                              IService<Config> service, SignInManager<AppUser> signInManager,
                              IService<Language> languageService, ILogger<HomeController> logger)
            : base(localizer, userManager)
        {
            _service = service;
            _signInManager = signInManager;
            _languageService = languageService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var langCode = rqf.RequestCulture.Culture;
            Debug.WriteLine(langCode);
            if (_languageService.Where(x => x.AdminStatus && x.Code == langCode.ToString()).FirstOrDefault() == null)
            {
                //eğer oturumdaki dile ulaşamıyor ise oturuma türkçe at
                Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("tr")),
                    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );
            }

            LayoutViewModel model = new LayoutViewModel();
            model.Config = await _service.GetByIdAsync(1);
            model.AppUser = await _userManager.GetUserAsync(HttpContext.User);
            model.Languages = await _languageService.Where(x => x.AdminStatus).ToListAsync();

            //log işleme alanı     
            LogContext.PushProperty("TypeName", "List");
            _logger.LogCritical(functions.LogCriticalMessage("List", ControllerContext.ActionDescriptor.ControllerName));

            if (!model.AppUser.Status)
            {
                return Redirect("~/Admin/Home/LogOut");
            }
            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/Admin/Login");
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
    }
}
