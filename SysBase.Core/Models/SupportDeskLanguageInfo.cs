namespace SysBase.Core.Models
{
    public class SupportDeskLanguageInfo : BaseEntityMultiLanguage
    {
        public int SupportDeskId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Url { get; set; }
        public SupportDesk SupportDesk { get; set; }
    }
}
