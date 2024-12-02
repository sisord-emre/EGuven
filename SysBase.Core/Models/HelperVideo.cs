namespace SysBase.Core.Models
{
    public class HelperVideo : BaseEntity
    {
        public int Sequence { get; set; }
        public string Image { get; set; }
        public string Video { get; set; }
        public bool MasterVideo { get; set; }
        public bool HomeVisibility { get; set; }
        public List<HelperVideoLanguageInfo> HelperVideoLanguageInfos { get; set; }
    }
}
