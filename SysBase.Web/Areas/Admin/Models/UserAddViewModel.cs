using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    public class UserAddViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public List<Menu> Menus { get; set; }
        public AppUser AppUser { get; set; }
        public List<AppRole> AppRoles { get; set; }
        public List<string> SelectedAppRoleIds { get; set; }
    }
}
