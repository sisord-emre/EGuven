using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysBase.Core.Models
{
    public class SoftwareCategoryLanguageInfo : BaseEntityMultiLanguage
    {
        public int SoftwareCategoryId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Slug { get; set; }
        public SoftwareCategory SoftwareCategory { get; set; }
    }
}
