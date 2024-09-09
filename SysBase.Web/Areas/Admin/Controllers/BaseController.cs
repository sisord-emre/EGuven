using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using SysBase.Core.Models;
using SysBase.Service.Functions;
using SysBase.Web.Resources;

namespace SysBase.Web.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // Instance of Functions class
        protected Functions functions = new Functions();

        // IHtmlLocalizer dependency for localization
        protected readonly IHtmlLocalizer<SharedResource> _localizer;

        // UserManager dependency for managing users
        protected readonly UserManager<AppUser> _userManager;

        // Constructor to initialize dependencies
        public BaseController(IHtmlLocalizer<SharedResource> localizer, UserManager<AppUser> userManager)
        {
            _localizer = localizer;
            _userManager = userManager;
        }
    }
}
