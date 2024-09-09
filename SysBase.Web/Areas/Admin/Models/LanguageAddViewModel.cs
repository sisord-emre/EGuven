using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    public class LanguageAddViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public Language Language { get; set; }
        public IEnumerable<LanguageKey> LanguageKeys { get; set; }
        public IEnumerable<LanguageValue> LanguageValues { get; set; }
    }
}
