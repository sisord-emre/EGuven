using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Index(AppUser model, [FromForm(Name = "cf-turnstile-response")] string cfTurnstileResponse)
        {
            string resCT = await functions.CloudflareTurnstile(cfTurnstileResponse);
            if (resCT != "1")
            {
                ModelState.AddModelError(string.Empty, resCT);
                TempData["message"] = resCT;
                return View(model);
            }

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

            // bu yapı crmden gelecek token göre giriş işlemi
            /*  
            model.CrmToken = "E123";
            // _userManager üzerinden kullanıcıyı CrmToken ile bul
            var hasUser = await _userManager.Users.FirstOrDefaultAsync(x => x.CrmToken == model.CrmToken);
            if (hasUser != null)
            {
                //log işleme alanı     
                LogContext.PushProperty("TypeName", "Sign in");
                _logger.LogCritical(functions.LogCriticalMessage("Sign in", ControllerContext.ActionDescriptor.ControllerName, hasUser.Id, JsonConvert.SerializeObject(model)));

                // Kullanıcı bulunduysa SignIn işlemi
                await _signInManager.SignInAsync(hasUser, isPersistent: false);
                return Redirect("~/Admin");              
            }
            else
            {
                // Kullanıcı bulunamadıysa hata veya yönlendirme
                ModelState.AddModelError(string.Empty, "Invalid CRM token.");
            }

            return View(await _service.GetByIdAsync(1));
            */
        }
    }
}
