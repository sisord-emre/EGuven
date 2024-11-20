using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    public class ProductSoftwareAddViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public ProductSoftware ProductSoftware { get; set; }
        public IEnumerable<Language> Languages { get; set; }
    }
}
