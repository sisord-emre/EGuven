using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    internal class SectoralReferenceListViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public List<SectoralReference> SectoralReferences { get; set; }
        public List<Sector> AppSectors { get; set; }
        public List<int> SelectedSectorIds { get; set; }
    }
}