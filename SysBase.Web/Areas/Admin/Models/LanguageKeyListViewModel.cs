using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    public class LanguageKeyListViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public LanguageKey LanguageKey { get; set; }
        public IEnumerable<LanguageKey> LanguageKeys { get; set; }
    }
}
