using SysBase.Core.Models;

namespace SysBase.Web.ViewModels
{
    public class BlogDetailViewModel : UiLayoutViewModel
    {
        public BlogLanguageInfo BlogLanguageInfo { get; set; }
        public List<BlogLanguageInfo> LastPosts { get; set; }
        public BlogLanguageInfo BeforeBlog { get; set; }
        public BlogLanguageInfo LastBlog { get; set; }
    }
}