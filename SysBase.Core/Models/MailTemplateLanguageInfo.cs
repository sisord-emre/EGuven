using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SysBase.Core.Models
{
    public class MailTemplateLanguageInfo : BaseEntityMultiLanguage
    {
        public int MailTemplateId { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        public MailTemplate MailTemplate { get; set; }
    }
}
