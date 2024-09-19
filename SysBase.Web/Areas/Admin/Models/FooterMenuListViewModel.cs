using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    internal class FooterMenuListViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public List<FooterMenu> FooterMenus { get; set; }
    }
}