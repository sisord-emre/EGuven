using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    internal class BrandAddViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public Brand Brand { get; set; }
        public int MaxSequence { get; set; }
    }
}