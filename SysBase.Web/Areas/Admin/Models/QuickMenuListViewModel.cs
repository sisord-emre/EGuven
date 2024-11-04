using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    public class QuickMenuListViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public List<QuickMenu> QuickMenus { get; set; }
    }
}
