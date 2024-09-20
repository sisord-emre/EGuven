using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    internal class BrandListViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
    }
}