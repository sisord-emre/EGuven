namespace SysBase.Core.Models
{
    public class Software : BaseEntity
    {
        public int SoftwareCategoryId { get; set; }
        public string Code { get; set; }
        public int Sequence { get; set; }
        public SoftwareCategory SoftwareCategory { get; set; }
        public List<SoftwareLanguageInfo> SoftwareLanguageInfos { get; set; }
    }
}
