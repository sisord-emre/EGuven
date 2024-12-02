using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    public class HomeProductListViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public List<HomeProductLanguageInfo> HomeProductLanguageInfos { get; set; }
    }
}
