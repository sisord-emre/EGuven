using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysBase.Core.Models
{
    public class SectoralReference : BaseEntity
    {
        public string Title { get; set; }
        public string Media { get; set; }
        public int Sequence { get; set; }
        public List<SectoralReferenceSector> SectoralReferenceSectors { get; set; }
    }
}
