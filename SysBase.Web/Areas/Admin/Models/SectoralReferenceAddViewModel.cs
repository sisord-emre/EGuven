using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    internal class SectoralReferenceAddViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public SectoralReference SectoralReference { get; set; }
        public List<Sector> AppSectors { get; set; }
        public List<int> SelectedSectorIds { get; set; }
        public int MaxSequence { get; set; }
    }
}