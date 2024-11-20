using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    public class HelperVideoAddViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public HelperVideo HelperVideo { get; set; }
        public IEnumerable<Language> Languages { get; set; }
    }
}
