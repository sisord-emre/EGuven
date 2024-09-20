using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    internal class SliderAddViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public Slider Slider { get; set; }
        public List<Language> Languages { get; set; }
    }
}