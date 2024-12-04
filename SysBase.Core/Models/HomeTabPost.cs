using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysBase.Core.Models
{
    public class HomeTabPost : BaseEntity
    {
        public int Sequence { get; set; }
        public List<HomeTabPostLanguageInfo> HomeTabPostLanguageInfos { get; set; }
    }
}
