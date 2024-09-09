using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    public class NotificationAddViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public Notification Notification { get; set; }
        public List<AppUser> AppUsers { get; set; }
        public List<string> SelectedUserIds { get; set; }
    }
}
