using Microsoft.EntityFrameworkCore;

namespace SysBase.Core.Models
{
    public class Product : BaseEntity
    {
        [Comment("1:Satın Alma,2:Yenileme")]
        public int Type { get; set; }
        public int Sequence { get; set; }
        public string Image { get; set; }
        public decimal Amount { get; set; }
        public decimal Tax { get; set; }
        [Comment("Paketin Kaç Yıllık Olduğu")]
        public int Year { get; set; }
        public List<ProductLanguageInfo> ProductLanguageInfos { get; set; }
        public List<ProjectProduct> ProjectProducts { get; set; }
    }
}
