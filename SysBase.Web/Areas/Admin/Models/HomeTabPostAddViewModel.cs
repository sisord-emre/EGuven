using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    internal class HomeTabPostAddViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public HomeTabPost HomeTabPost { get; set; }
        public IEnumerable<Language> Languages { get; set; }
    }
}