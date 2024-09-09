using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    public class NotificationListViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public List<Notification> Notifications { get; set; }
        public int UnseenNotificationCount { get; set; }
        public List<AppUser> AppUsers { get; set; }
        public List<string> SelectedUserIds { get; set; }
    }
}
