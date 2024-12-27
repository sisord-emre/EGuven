using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysBase.Core.Models
{
    public class MailTemplate : BaseEntity
    {
        public string Code { get; set; }
        public int Sequence { get; set; }
        public List<MailTemplateLanguageInfo> MailTemplateLanguageInfos { get; set; }
    }
}
