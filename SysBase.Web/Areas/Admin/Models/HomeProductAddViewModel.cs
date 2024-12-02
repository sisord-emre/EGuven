using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    public class HomeProductAddViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public HomeProduct HomeProduct { get; set; }
        public IEnumerable<Language> Languages { get; set; }
    }
}
