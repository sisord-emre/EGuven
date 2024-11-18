namespace SysBase.Core.Models
{
    public class SupportDesk : BaseEntity
    {
        public int Sequence { get; set; }
        public string Image { get; set; }
        public List<SupportDeskLanguageInfo> SupportDeskLanguageInfos { get; set; }
    }
}
