using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SysBase.Core.Models;
using SysBase.Repository;

namespace SysBase.Web.Areas.Admin.ViewComponents
{
    public class MenuViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public MenuViewComponent(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);

            List<Menu> list = _context.Menus.Where(x => x.SpecialVisibility == true && x.Visibility == true).OrderBy(X => X.Sequence).ToList();
            ViewData["MenuPermission"] = JsonConvert.DeserializeObject<List<MenuPermission>>(currentUser.MenuPermissions);

            return View(list);
        }
    }
}
