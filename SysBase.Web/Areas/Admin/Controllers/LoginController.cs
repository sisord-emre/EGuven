using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog.Context;
using SysBase.Core.Models;
using SysBase.Core.Services;
using SysBase.Service.Functions;

namespace SysBase.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly IService<Config> _service;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        protected readonly ILogger<LoginController> _logger;
        protected Functions functions = new Functions();

        public LoginController(IService<Config> service, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ILogger<LoginController> logger)
        {
            _service = service;
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetByIdAsync(1));
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUser model)
        {
            var hasUser = await _userManager.FindByEmailAsync(model.Email);
            if (hasUser == null)
            {
                ModelState.AddModelError(string.Empty, "Email Veya Şifre Yanlış");
                TempData["message"] = "Email Veya Şifre Yanlış";
                return View(model);
            }
            var result = await _signInManager.PasswordSignInAsync(hasUser, model.PasswordHash, false, false);
            if (result.Succeeded)
            {
                return Redirect("~/Admin");
            }

            TempData["message"] = "Email Veya Şifre Yanlış";
            ModelState.AddModelError(string.Empty, "Email Veya Şifre Yanlış");

            //log işleme alanı     
            LogContext.PushProperty("TypeName", "Sign in");
            _logger.LogCritical(functions.LogCriticalMessage("Sign in", ControllerContext.ActionDescriptor.ControllerName, hasUser.Id, JsonConvert.SerializeObject(model)));

            return View(await _service.GetByIdAsync(1));
        }
    }
}
