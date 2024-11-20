using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    public class ProductSoftwareListViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public List<ProductSoftwareLanguageInfo> ProductSoftwareLanguageInfos { get; set; }
    }
}
