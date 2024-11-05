using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    public class AnnouncementAddViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public Announcement Announcement { get; set; }
        public IEnumerable<Language> Languages { get; set; }
    }
}
