using SysBase.Core.Models;

namespace SysBase.Web.ViewModels
{
    public class ContactViewModel : UiLayoutViewModel
    {
        public PageLanguageInfo CompanyInformation { get; set; }
        public PageLanguageInfo AccountNumber { get; set; }
    }
}