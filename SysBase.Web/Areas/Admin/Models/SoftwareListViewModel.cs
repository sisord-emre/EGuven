using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    public class SoftwareListViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public List<SoftwareLanguageInfo> SoftwareLanguageInfos { get; set; }
    }
}
