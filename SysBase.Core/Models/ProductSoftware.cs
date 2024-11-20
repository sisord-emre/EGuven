namespace SysBase.Core.Models
{
    public class ProductSoftware : BaseEntity
    {
        public int Sequence { get; set; }
        public string Image { get; set; }
        public List<ProductSoftwareLanguageInfo> ProductSoftwareLanguageInfos { get; set; }
    }
}
