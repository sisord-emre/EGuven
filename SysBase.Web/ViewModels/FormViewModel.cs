using SysBase.Core.Models;

namespace SysBase.Web.ViewModels
{
    public class FormViewModel : UiLayoutViewModel
    {
        public List<ProjectProduct> ProjectProducts { get; set; }
        public List<ProjectField> ProjectFields { get; set; }
        public List<City> Cities { get; set; }
        public ConfigLanguageInfo ConfigLanguageInfo { get; set; }
        public Company Company{ get; set; }
        public CompanyInvoice CompanyInvoice { get; set; }
        public PageLanguageInfo AydinlatmaMetni { get; set; }
        public PageLanguageInfo HavaleEft { get; set; }
        public PageLanguageInfo OnBilgilendirme { get; set; }
        public PageLanguageInfo MesafeliSatis { get; set; }
    }
}
