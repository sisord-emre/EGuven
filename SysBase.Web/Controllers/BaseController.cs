using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using SysBase.Core.Models;
using SysBase.Core.Services;
using SysBase.Service.Functions;
using SysBase.Web.Resources;

namespace SysBase.Web.Controllers
{
    public class BaseController : Controller
    {
        // Instance of Functions class
        protected Functions functions = new Functions();

        // IHtmlLocalizer dependency for localization
        protected readonly IHtmlLocalizer<SharedResource> _localizer;

        protected readonly IService<Config> _service;

        // Constructor to initialize dependencies
        public BaseController(IHtmlLocalizer<SharedResource> localizer, IService<Config> service)
        {
            _localizer = localizer;
            _service = service;
        }
    }
}
