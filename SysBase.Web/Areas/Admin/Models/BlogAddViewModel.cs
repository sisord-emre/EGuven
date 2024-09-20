using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    internal class BlogAddViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public Blog Blog { get; set; }
        public IEnumerable<Language> Languages { get; set; }
    }
}