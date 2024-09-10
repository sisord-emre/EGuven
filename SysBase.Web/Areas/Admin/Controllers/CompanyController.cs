using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog.Context;
using SysBase.Core.Models;
using SysBase.Core.Services;
using SysBase.Web.Areas.Admin.Models;
using SysBase.Web.Resources;

namespace SysBase.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class CompanyController : BaseController
    {
        // PageController specific dependencies
        protected readonly IService<Company> _service;
        protected readonly ILogger<CompanyController> _logger;

        public CompanyController(IHtmlLocalizer<SharedResource> localizer, UserManager<AppUser> userManager,
                              IService<Company> service, ILogger<CompanyController> logger)
            : base(localizer, userManager)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<IActionResult> Add(string Id = null)
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            // Şartlara göre kullanıcıları filtrele
            var usersInCorporateSalesRepresentative = await _userManager.GetUsersInRoleAsync("Kurumsal Satış Temsilcisi");
            var usersInOperationRepresentative = await _userManager.GetUsersInRoleAsync("Firma Operasyon Temsilcisi");
            Company model = null;
            if (Id != null)
            {
                model = await _service.GetByIdAsync(Int32.Parse(Id));
            }

            //log işleme alanı     
            LogContext.PushProperty("TypeName", "List");
            _logger.LogCritical(functions.LogCriticalMessage("List", ControllerContext.ActionDescriptor.ControllerName, Id));

            return View
            (
                new CompanyAddViewModel
                {
                    MenuPermission = menuPermission, 
                    Company = model, 
                    UsersInCorporateSalesRepresentative = (List<AppUser>)usersInCorporateSalesRepresentative, 
                    UsersInOperationRepresentative = (List<AppUser>)usersInOperationRepresentative
                }
            );
        }

        [HttpPost]
        public async Task<IActionResult> Add(Company model)
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            Company isControl;
            if (ModelState.IsValid)
            {
                isControl = await _service.UpdateAsync(model);

                //log işleme alanı
                LogContext.PushProperty("TypeName", "Update");
                _logger.LogCritical(functions.LogCriticalMessage("Update", ControllerContext.ActionDescriptor.ControllerName, isControl.Id.ToString(), JsonConvert.SerializeObject(model)));
            }
            else
            {
                isControl = await _service.AddAsync(model);

                //log işleme alanı
                LogContext.PushProperty("TypeName", ControllerContext.ActionDescriptor.ActionName);
                _logger.LogCritical(functions.LogCriticalMessage(ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName, isControl.Id.ToString(), JsonConvert.SerializeObject(model)));
            }
            if (isControl.Id != 0)
            {
                TempData["SuccessMessage"] = _localizer["admin.Kayıt İşlemi Başarıyle Gerçekleşmiştir."].Value;
            }
            else
            {
                TempData["ErrorMessage"] = _localizer["admin.Bilgileri Kontrol Ediniz"].Value;
            }

            // Şartlara göre kullanıcıları filtrele
            var usersInCorporateSalesRepresentative = await _userManager.GetUsersInRoleAsync("Kurumsal Satış Temsilcisi");
            var usersInOperationRepresentative = await _userManager.GetUsersInRoleAsync("Firma Operasyon Temsilcisi");

            return View
            (
                new CompanyAddViewModel 
                { 
                    MenuPermission = menuPermission, 
                    Company = model,
                    UsersInCorporateSalesRepresentative = (List<AppUser>)usersInCorporateSalesRepresentative,
                    UsersInOperationRepresentative = (List<AppUser>)usersInOperationRepresentative
                }
            );
        }

        public async Task<IActionResult> List()
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            //log işleme alanı
            LogContext.PushProperty("TypeName", ControllerContext.ActionDescriptor.ActionName);
            _logger.LogCritical(functions.LogCriticalMessage(ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName));
            
            // Şartlara göre kullanıcıları filtrele
            var usersInCorporateSalesRepresentative = await _userManager.GetUsersInRoleAsync("Kurumsal Satış Temsilcisi");
            var usersInOperationRepresentative = await _userManager.GetUsersInRoleAsync("Firma Operasyon Temsilcisi");

            return View
            (
                new CompanyListViewModel 
                { 
                    MenuPermission = menuPermission, 
                    Companys = await _service.Where(x => x.Status).ToListAsync(),
                    UsersInCorporateSalesRepresentative = (List<AppUser>)usersInCorporateSalesRepresentative,
                    UsersInOperationRepresentative = (List<AppUser>)usersInOperationRepresentative
                }
            );
        }

        public async Task<ResultJson> Delete(string Id = null)
        {
            ResultJson resultJson = new ResultJson();
            resultJson.status = "error";
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                resultJson.message = _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value;
                return resultJson;
            }

            if (Id != null)
            {
                Company item = await _service.GetByIdAsync(Int32.Parse(Id));
                if (item != null)
                {
                    await _service.RemoveAsync(item);
                    resultJson.status = "success";
                    return resultJson;
                }
            }

            //log işleme alanı
            LogContext.PushProperty("TypeName", ControllerContext.ActionDescriptor.ActionName);
            _logger.LogCritical(functions.LogCriticalMessage(ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName, Id));

            return resultJson;
        }
    }
}
