using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog.Context;
using SysBase.Core.Models;
using SysBase.Core.Services;
using SysBase.Service.Functions;
using SysBase.Web.Resources;
using System.Diagnostics;

namespace SysBase.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly IService<Config> _service;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        protected readonly ILogger<LoginController> _logger;
        protected readonly IHtmlLocalizer<SharedResource> _localizer;
        protected Functions functions = new Functions();

        public LoginController(IService<Config> service, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ILogger<LoginController> logger, IHtmlLocalizer<SharedResource> localizer)
        {
            _service = service;
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _localizer = localizer;
        }

        public async Task<IActionResult> Index()
        {
            Config config = await _service.GetByIdAsync(1);
            if (config.IpControl && config.AllowedIPList != "" && config.AllowedIPList != null)
            {
                string[] ipList = config.AllowedIPList.Split(';');
                string ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
                if (!ipList.Contains(ipAddress))
                {
                    return Content(_localizer["admin.IP Adresinizi İzinli Listede Bulunamadı."].Value);
                }
            }

            return View(config);
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
                ModelState.AddModelError(string.Empty, _localizer["admin.Email Veya Şifre Yanlış"].Value);
                TempData["message"] = _localizer["admin.Email Veya Şifre Yanlış"].Value;
                return View(model);
            }
            var result = await _signInManager.PasswordSignInAsync(hasUser, model.PasswordHash, false, false);
            if (result.Succeeded)
            {
                return Redirect("~/Admin");
            }

            TempData["message"] = _localizer["admin.Email Veya Şifre Yanlış"].Value;
            ModelState.AddModelError(string.Empty, _localizer["admin.Email Veya Şifre Yanlış"].Value);

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
