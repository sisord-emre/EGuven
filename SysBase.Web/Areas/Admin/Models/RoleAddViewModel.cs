using Microsoft.AspNetCore.Identity;
using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    internal class RoleAddViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public List<Menu> Menus { get; set; }
        public AppRole AppRole { get; set; }
    }
}