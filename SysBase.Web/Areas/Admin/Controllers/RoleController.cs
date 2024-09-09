using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    public class RoleController : BaseController
    {
        // RoleController specific dependency
        protected readonly RoleManager<AppRole> _roleManager;
        protected readonly IService<Menu> _menuService;
        protected readonly ILogger<RoleController> _logger;

        public RoleController(UserManager<AppUser> userManager, IHtmlLocalizer<SharedResource> localizer,
            RoleManager<AppRole> roleManager, IService<Menu> menuService, ILogger<RoleController> logger)
            : base(localizer, userManager)
        {
            _roleManager = roleManager;
            _menuService = menuService;
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

            AppRole role = null;
            List<Menu> menus = await _menuService.Where(x => x.SpecialVisibility == true && x.UpMenuId == 0).OrderBy(x => x.Sequence).ToListAsync();
            if (Id != null)
            {
                role = await _roleManager.FindByIdAsync(Id);
            }

            //log işleme alanı     
            LogContext.PushProperty("TypeName", "List");
            _logger.LogCritical(functions.LogCriticalMessage("List", ControllerContext.ActionDescriptor.ControllerName, Id));

            return View(new RoleAddViewModel { MenuPermission = menuPermission, Menus = menus, AppRole = role });
        }

        [HttpPost]
        public async Task<IActionResult> Add(AppRole model, int[] List, int[] Add, int[] Edit, int[] Delete, int[] Export)
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            List<Menu> menus = await _menuService.Where(x => x.SpecialVisibility == true && x.UpMenuId == 0).OrderBy(X => X.Sequence).ToListAsync();
            List<MenuPermission> menuPermissions = new List<MenuPermission>();
            foreach (Menu item in menus)
            {
                MenuPermission addItem = new MenuPermission();
                addItem.MenuId = item.Id;
                addItem.ControllerName = item.ControllerName;
                if (List.Contains(item.Id))
                {
                    addItem.List = true;
                }
                if (Add.Contains(item.Id))
                {
                    addItem.Add = true;
                }
                if (Edit.Contains(item.Id))
                {
                    addItem.Edit = true;
                }
                if (Delete.Contains(item.Id))
                {
                    addItem.Delete = true;
                }
                if (Export.Contains(item.Id))
                {
                    addItem.Export = true;
                }
                menuPermissions.Add(addItem);
            }
            string menuPermissionsJSON = JsonConvert.SerializeObject(menuPermissions);

            IdentityResult isControl;
            if (!string.IsNullOrEmpty(model.Id))
            {
                AppRole role = await _roleManager.FindByIdAsync(model.Id);
                role.Name = model.Name;
                role.Status = model.Status;
                role.MenuPermissions = menuPermissionsJSON;
                // Here you would also update any additional properties related to roles and permissions
                isControl = await _roleManager.UpdateAsync(role);

                //log işleme alanı
                LogContext.PushProperty("TypeName", "Update");
                _logger.LogCritical(functions.LogCriticalMessage("Update", ControllerContext.ActionDescriptor.ControllerName, model.Id, JsonConvert.SerializeObject(model)));
            }
            else
            {
                AppRole role = new AppRole { Name = model.Name, Status = model.Status, MenuPermissions = menuPermissionsJSON};
                isControl = await _roleManager.CreateAsync(role);

                //log işleme alanı
                LogContext.PushProperty("TypeName", ControllerContext.ActionDescriptor.ActionName);
                _logger.LogCritical(functions.LogCriticalMessage(ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName, model.Id, JsonConvert.SerializeObject(model)));
            }           

            if (isControl.Succeeded)
            {
                TempData["SuccessMessage"] = _localizer["admin.Kayıt İşlemi Başarıyle Gerçekleşmiştir."].Value;
            }
            else
            {
                TempData["ErrorMessage"] = _localizer["admin.Bilgileri Kontrol Ediniz"].Value;
            }

            return View(new RoleAddViewModel { MenuPermission = menuPermission, Menus = menus, AppRole = model });
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

            return View(new RoleListViewModel { MenuPermission = menuPermission, AppRoles = _roleManager.Roles.ToList() });
        }

        public async Task<IActionResult> Detail(string Id = null)
        {
            if (Id != null)
            {
                return View(await _roleManager.FindByIdAsync(Id));
            }

            //log işleme alanı
            LogContext.PushProperty("TypeName", "List");
            _logger.LogCritical(functions.LogCriticalMessage("List", ControllerContext.ActionDescriptor.ControllerName, Id));

            return View();
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
                AppRole role = await _roleManager.FindByIdAsync(Id);
                if (role != null)
                {
                    IdentityResult result = await _roleManager.DeleteAsync(role);
                    if (result.Succeeded)
                    {
                        resultJson.status = "success";
                        return resultJson;
                    }
                    else
                    {
                        foreach (IdentityError item in result.Errors)
                        {
                            resultJson.message += item.Description;
                            ModelState.AddModelError(string.Empty, item.Description);
                        }
                    }
                }
            }

            //log işleme alanı
            LogContext.PushProperty("TypeName", ControllerContext.ActionDescriptor.ActionName);
            _logger.LogCritical(functions.LogCriticalMessage(ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName, Id));

            return resultJson;
        }
    }
}
