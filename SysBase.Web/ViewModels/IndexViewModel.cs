using SysBase.Core.Models;

namespace SysBase.Web.ViewModels
{
    public class IndexViewModel : UiLayoutViewModel
    {
        public List<Slider> Sliders { get; set; }
        public List<AnnouncementLanguageInfo> Announcements { get; set; }
        public List<Brand> Brands { get; set; }
        public List<BlogLanguageInfo> BlogLanguageInfos { get; set; }
        public List<HelperVideoLanguageInfo> HelperVideoLanguageInfos { get; set; }
        public HelperVideoLanguageInfo HelperVideoLanguageInfo { get; set; }
        public List<HomeProductLanguageInfo> HomeProductLanguageInfos { get; set; }
        public List<HomeTabPostLanguageInfo> HomeTabPostLanguageInfos { get; set; }
    }
}
