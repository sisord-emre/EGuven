namespace SysBase.Core.Models
{
    public class Announcement : BaseEntity
    {
        public int Sequence { get; set; }
        public List<AnnouncementLanguageInfo> AnnouncementLanguageInfos { get; set; }
    }
}
