using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    internal class CompanyAddViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public Company Company { get; set; }
        public List<AppUser> UsersInCorporateSalesRepresentative { get; set; }
        public List<AppUser> UsersInOperationRepresentative { get; set; }
    }
}