using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    public class PageAddViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public Page Page { get; set; }
        public IEnumerable<Language> Languages { get; set; }
    }
}
