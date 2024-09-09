namespace SysBase.Core.Models
{
    public class LanguageValue
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public int LanguageKeyId { get; set; }
        public string Text { get; set; }
        public Language Language { get; set; }
        public LanguageKey LanguageKey { get; set; }
    }
}
