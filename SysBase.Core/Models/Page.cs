using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SysBase.Core.Models
{
    public class Page : BaseEntity
    {
        public string Code { get; set; }
        public int Sequence { get; set; }
        public bool FooterVisibility { get; set; }
        public List<PageLanguageInfo> PageLanguageInfos { get; set; }
    }
}
