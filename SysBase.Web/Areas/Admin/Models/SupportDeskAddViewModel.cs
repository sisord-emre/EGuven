using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    public class SupportDeskAddViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public SupportDesk SupportDesk { get; set; }
        public IEnumerable<Language> Languages { get; set; }
    }
}
