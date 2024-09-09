using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SysBase.Core.Models
{
    public class PageLanguageInfo : BaseEntityMultiLanguage
    {
        public int PageId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        public Page Page { get; set; }
    }
}
