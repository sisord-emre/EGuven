using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    public class QuickMenuAddViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public QuickMenu QuickMenu { get; set; }
        public List<Language> Languages { get; set; }
    }
}
