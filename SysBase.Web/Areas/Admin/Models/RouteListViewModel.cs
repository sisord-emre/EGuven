using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    internal class RouteListViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public IEnumerable<Core.Models.Route> Routes { get; set; }
    }
}