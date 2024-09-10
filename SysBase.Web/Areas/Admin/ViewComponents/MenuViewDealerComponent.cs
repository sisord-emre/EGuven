using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SysBase.Core.Models;
using SysBase.Core.Services;
using SysBase.Repository;

namespace SysBase.Web.Areas.Admin.ViewComponents
{
    public class MenuViewDealerComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        protected readonly IService<AppUserRole> _appUserRoleService;
        protected readonly IService<AppRole> _appRoleService;

        public MenuViewDealerComponent(AppDbContext context, UserManager<AppUser> userManager, IService<AppUserRole> appUserRoleService, IService<AppRole> appRoleService)
        {
            _context = context;
            _userManager = userManager;
            _appUserRoleService = appUserRoleService;
            _appRoleService = appRoleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Şu anki kullanıcıyı al
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var userRole = await _appUserRoleService
                .Where(x => x.UserId == currentUser.Id)
                .FirstOrDefaultAsync();

            var rolePermission = await _appRoleService
                .Where(x => x.Id == userRole.RoleId)
                .FirstOrDefaultAsync();

            // Eğer bir kullanıcı rolü varsa, AppRole bilgisine eriş
            List<Menu> list = _context.Menus.Where(x => x.SpecialVisibility == true && x.Visibility == true).OrderBy(X => X.Sequence).ToList();
            if (rolePermission != null)
            {
                ViewData["MenuPermission"] = JsonConvert.DeserializeObject<List<MenuPermission>>(rolePermission.MenuPermissions);
            }
            else
            {
                // Kullanıcının rolü yoksa bir işlem yapabilirsiniz
                ViewData["MenuPermission"] = JsonConvert.DeserializeObject<List<MenuPermission>>(currentUser.MenuPermissions);
            }

            return View(list);
        }
    }

}
