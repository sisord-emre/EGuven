using Microsoft.EntityFrameworkCore;

namespace SysBase.Core.Models
{
    public class ProductLanguageInfo : BaseEntityMultiLanguage
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public Product Product { get; set; }
    }
}
