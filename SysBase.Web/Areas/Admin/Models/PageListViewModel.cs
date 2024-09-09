using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    public class PageListViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public IEnumerable<PageLanguageInfo> PageLanguageInfos { get; set; }
    }
}
