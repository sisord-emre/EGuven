using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    public class UserListViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}
