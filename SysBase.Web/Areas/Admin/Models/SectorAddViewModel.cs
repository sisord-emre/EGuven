using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    internal class SectorAddViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public Sector Sector { get; set; }
        public IEnumerable<Language> Languages { get; set; }
    }
}