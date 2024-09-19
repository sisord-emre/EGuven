using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    internal class SiteMenuListViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public List<SiteMenu> SiteMenus { get; set; }
    }
}