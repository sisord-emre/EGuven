using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    internal class ProjectAddViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public Project Project { get; set; }
        public List<Company> Companys { get; set; }
        public List<CompanyInvoice> CompanyInvoices { get; set; }
        public List<ProductLanguageInfo> ProductLanguageInfos { get; set; }
        public List<ProjectProduct> ProjectProducts { get; set; }
        public List<FieldGroup> FieldGroups { get; set; }
        public List<ProjectField> ProjectFields { get; set; }
        public List<Project> Projects { get; set; }
    }
}