namespace SysBase.Core.Models
{
    public class HomeProduct : BaseEntity
    {
        public string Image { get; set; }
        public int Sequence { get; set; }
        public List<HomeProductLanguageInfo> HomeProductLanguageInfos { get; set; }
    }
}
