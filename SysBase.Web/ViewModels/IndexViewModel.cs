using SysBase.Core.Models;

namespace SysBase.Web.ViewModels
{
    public class IndexViewModel : UiLayoutViewModel
    {
        public List<Slider> Sliders { get; set; }
        public List<AnnouncementLanguageInfo> Announcements { get; set; }
        public List<Brand> Brands { get; set; }
        public List<BlogLanguageInfo> BlogLanguageInfos { get; set; }
    }
}
