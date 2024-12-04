using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    internal class HomeTabPostListViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public List<HomeTabPostLanguageInfo> HomeTabPostLanguageInfos { get; set; }
    }
}