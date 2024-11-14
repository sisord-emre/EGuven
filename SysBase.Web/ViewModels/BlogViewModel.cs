using SysBase.Core.Models;

namespace SysBase.Web.ViewModels
{
    public class BlogViewModel : UiLayoutViewModel
    {
        public List<BlogLanguageInfo> BlogLanguageInfos { get; set; }
        public List<BlogLanguageInfo> LastPosts { get; set; }
    }
}