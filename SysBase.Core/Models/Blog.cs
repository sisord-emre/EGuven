using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SysBase.Core.Models
{
    public class Blog : BaseEntity
    {
        public string Code { get; set; }
        public string Image { get; set; }
        public int Type { get; set; }
        public int ReadTime { get; set; }
        public DateTime PublicationTime { get; set; }
        public int Sequence { get; set; }
        public List<BlogLanguageInfo> BlogLanguageInfos { get; set; }
    }
}
