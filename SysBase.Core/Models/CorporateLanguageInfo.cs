using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SysBase.Core.Models
{
    public class CorporateLanguageInfo : BaseEntityMultiLanguage
    {
        public int CorporateId { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        public string SubTitle { get; set; }
        public string SubDescription { get; set; }
        public string Media { get; set; }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Visionmission { get; set; }
        public bool VisionmissionStatus { get; set; }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Values { get; set; }
        public bool ValuesStatus { get; set; }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Kss { get; set; }
        public bool KssStatus { get; set; }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Document { get; set; }
        public bool DocumentStatus { get; set; }
        public Corporate Corporate { get; set; }
    }
}