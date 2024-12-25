using SysBase.Core.Models;

namespace SysBase.Web.ViewModels
{
    public class FormViewModel : UiLayoutViewModel
    {
        public List<ProjectProduct> ProjectProducts { get; set; }
        public List<ProjectField> ProjectFields { get; set; }
        public List<City> Cities { get; set; }
        public ConfigLanguageInfo ConfigLanguageInfo { get; set; }
    }
}
