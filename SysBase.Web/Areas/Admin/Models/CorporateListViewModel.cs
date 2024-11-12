using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    internal class CorporateListViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public List<CorporateLanguageInfo> CorporateLanguageInfos { get; set; }
    }
}