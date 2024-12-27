using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    internal class RouteAddViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public Core.Models.Route Route { get; set; }
        public IEnumerable<Language> Languages { get; set; }
    }
}