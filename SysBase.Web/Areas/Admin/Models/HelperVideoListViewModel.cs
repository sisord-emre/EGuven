using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    public class HelperVideoListViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public Software Software { get; set; }
        public IEnumerable<Language> Languages { get; set; }
        public IEnumerable<HelperVideoLanguageInfo> HelperVideoLanguageInfos { get; set; }
    }
}
