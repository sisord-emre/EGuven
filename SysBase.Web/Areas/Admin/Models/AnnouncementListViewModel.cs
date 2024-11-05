using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    public class AnnouncementListViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public List<AnnouncementLanguageInfo> AnnouncementLanguageInfos { get; set; }
    }
}
