using Microsoft.EntityFrameworkCore;

namespace SysBase.Core.Models
{
    public class SoftwareLanguageInfo : BaseEntityMultiLanguage
    {
        public int SoftwareId { get; set; }
        public string Title { get; set; }
        [Comment("1:Url, 2:File Upload")]
        public int Type { get; set; }
        public string File { get; set; }
        public string FileUrl { get; set; }
        public Software Software { get; set; }
    }
}
