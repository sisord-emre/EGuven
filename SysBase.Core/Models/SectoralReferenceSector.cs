using System.Numerics;

namespace SysBase.Core.Models
{
    public class SectoralReferenceSector
    {
        public int Id { get; set; }
        public int SectoralReferenceId { get; set; }
        public int SectorId { get; set; }
        public SectoralReference SectoralReference { get; set; }
        public Sector Sector { get; set; }
    }
}