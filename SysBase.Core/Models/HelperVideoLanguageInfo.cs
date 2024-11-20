namespace SysBase.Core.Models
{
    public class HelperVideoLanguageInfo : BaseEntityMultiLanguage
    {
        public int HelperVideoId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public HelperVideo HelperVideo { get; set; }
    }
}
