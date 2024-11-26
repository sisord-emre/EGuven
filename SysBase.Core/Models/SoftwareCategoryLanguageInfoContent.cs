using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SysBase.Core.Models
{
    public class SoftwareCategoryLanguageInfoContent : BaseEntity
    {
        public int SoftwareCategoryLanguageInfoId { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
        public int Sequence { get; set; }
        public SoftwareCategoryLanguageInfo SoftwareCategoryLanguageInfo { get; set; }
    }
}
