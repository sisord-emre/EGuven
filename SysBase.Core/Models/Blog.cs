namespace SysBase.Core.Models
{
    public class Blog : BaseEntity
    {
        public string Code { get; set; }
        public string Image { get; set; }
        public int Type { get; set; }
        public int ReadTime { get; set; }
        public DateTime PublicationTime { get; set; }
        public int Sequence { get; set; }
        public List<BlogLanguageInfo> BlogLanguageInfos { get; set; }
    }
}
