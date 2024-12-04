using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SysBase.Core.Models
{
    public class HomeTabPostLanguageInfoContent : BaseEntity
    {
        public int HomeTabPostLanguageInfoId { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
        public int Sequence { get; set; }
        public HomeTabPostLanguageInfo HomeTabPostLanguageInfo { get; set; }
    }
}
