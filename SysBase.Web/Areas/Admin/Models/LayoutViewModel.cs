using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    public class LayoutViewModel
    {
        public Config Config { get; set; }
        public AppUser AppUser { get; set; }
        public List<Language> Languages { get; set; }
    }
}
