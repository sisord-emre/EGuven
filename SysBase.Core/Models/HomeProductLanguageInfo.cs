namespace SysBase.Core.Models
{
    public class HomeProductLanguageInfo : BaseEntityMultiLanguage
    {
        public int HomeProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public HomeProduct HomeProduct { get; set; }
    }
}
