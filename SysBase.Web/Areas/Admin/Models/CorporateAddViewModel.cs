using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    internal class CorporateAddViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public Corporate Corporate { get; set; }
        public IEnumerable<Language> Languages { get; set; }
    }
}