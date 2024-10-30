using SysBase.Core.Models;

namespace SysBase.Web.ViewModels
{
    public class UiLayoutViewModel
    {
        public Config Config { get; set; }
        public List<SiteMenu> SiteMenus { get; set; }
        public List<FooterMenu> FooterMenus { get; set; }
        public List<Language> Languages { get; set; }
    }
}
