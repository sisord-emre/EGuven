using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    public class ProductAddViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public Product Product { get; set; }
        public IEnumerable<Language> Languages { get; set; }
    }
}
