using DocumentFormat.OpenXml.Drawing.Charts;

namespace SysBase.Core.Models
{
    public class Blog : BaseEntity
    {
        public int BlogTypeId { get; set; }
        public string Code { get; set; }
        public string Image { get; set; }
        public int ReadTime { get; set; }
        public DateTime PublicationTime { get; set; }
        public int Sequence { get; set; }
        public bool HomeVisibility { get; set; }
        public List<BlogLanguageInfo> BlogLanguageInfos { get; set; }
        public BlogType BlogType { get; set; }
    }
}
