using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    public class SoftwareCategoryListViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public List<SoftwareCategoryLanguageInfo> SoftwareCategoryLanguageInfos { get; set; }
    }
}
