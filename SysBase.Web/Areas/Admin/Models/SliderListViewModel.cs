using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    internal class SliderListViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public IEnumerable<Slider> Sliders { get; set; }
    }
}