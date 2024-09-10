using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    internal class CompanyListViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public List<Company> Companys { get; set; }
        public List<AppUser> UsersInCorporateSalesRepresentative { get; set; }
        public List<AppUser> UsersInOperationRepresentative { get; set; }
    }
}