using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    public class SoftwareCategoryAddViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public SoftwareCategory SoftwareCategory { get; set; }
        public IEnumerable<Language> Languages { get; set; }
    }
}
