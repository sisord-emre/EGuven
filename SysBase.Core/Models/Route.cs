using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysBase.Core.Models
{
    public class Route : BaseEntity
    {
        public string Url1 { get; set; }
        public string Url2 { get; set; }
        public int StatusCode { get; set; }
    }
}
