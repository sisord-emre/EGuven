using SysBase.Core.Models;

namespace SysBase.Web.ViewModels
{
    public class SectoralReferenceViewModel : UiLayoutViewModel
    {
        public List<SectoralReference> SectoralReferences { get; set; }
        public List<SectorLanguageInfo> SectorLanguageInfos { get; set; }
    }
}