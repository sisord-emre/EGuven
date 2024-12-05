using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    internal class BlogTypeListViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public IEnumerable<BlogType> BlogTypes { get; set; }
    }
}