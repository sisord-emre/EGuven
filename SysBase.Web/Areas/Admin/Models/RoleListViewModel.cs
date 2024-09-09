using Microsoft.AspNetCore.Identity;
using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    internal class RoleListViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public List<AppRole> AppRoles { get; set; }
    }
}