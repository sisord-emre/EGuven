using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    internal class BlogListViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public List<BlogLanguageInfo> BlogLanguageInfos { get; set; }
    }
}