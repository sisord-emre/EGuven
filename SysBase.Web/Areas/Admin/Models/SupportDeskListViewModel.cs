using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    public class SupportDeskListViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public List<SupportDeskLanguageInfo> SupportDeskLanguageInfos { get; set; }
    }
}
