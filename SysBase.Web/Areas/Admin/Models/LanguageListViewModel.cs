using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    public class LanguageListViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public IEnumerable<Language> Languages { get; set; }
    }
}
