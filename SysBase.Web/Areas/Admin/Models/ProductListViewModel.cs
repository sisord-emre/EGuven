using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    public class ProductListViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public List<ProductLanguageInfo> ProductLanguageInfos { get; set; }
    }
}
