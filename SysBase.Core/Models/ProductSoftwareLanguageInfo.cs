using Microsoft.EntityFrameworkCore;

namespace SysBase.Core.Models
{
    public class ProductSoftwareLanguageInfo : BaseEntityMultiLanguage
    {
        public int ProductSoftwareId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        [Comment("1:Url, 2:File Upload")]
        public int Type { get; set; }
        public string File { get; set; }
        public string FileUrl { get; set; }
        public ProductSoftware ProductSoftware { get; set; }
    }
}
