namespace SysBase.Core.Models
{
    public class SoftwareCategory : BaseEntity
    {
        public int Sequence { get; set; }
        public string Image { get; set; }
        public List<Software> Softwares { get; set; }
        public List<SoftwareCategoryLanguageInfo> SoftwareCategoryLanguageInfos { get; set; }
    }
}
