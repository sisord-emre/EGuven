using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    internal class ProjectListViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public List<Project> Projects { get; set; }
        public List<Company> Companys { get; set; }
    }
}