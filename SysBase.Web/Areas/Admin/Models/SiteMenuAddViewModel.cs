using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    internal class SiteMenuAddViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public SiteMenu SiteMenu { get; set; }
    }
}