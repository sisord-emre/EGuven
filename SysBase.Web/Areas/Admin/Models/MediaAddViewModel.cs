using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    internal class MediaAddViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public Media Media { get; set; }
        public IEnumerable<Language> Languages { get; set; }
    }
}