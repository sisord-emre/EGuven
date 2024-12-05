using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    internal class BlogTypeAddViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public BlogType BlogType { get; set; }
        public IEnumerable<Language> Languages { get; set; }
    }
}