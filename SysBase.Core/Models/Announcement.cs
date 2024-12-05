namespace SysBase.Core.Models
{
    public class Announcement : BaseEntity
    {
        public int Sequence { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<AnnouncementLanguageInfo> AnnouncementLanguageInfos { get; set; }
    }
}
