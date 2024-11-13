using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    internal class SectorListViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public List<SectorLanguageInfo> SectorLanguageInfos { get; set; }
    }
}