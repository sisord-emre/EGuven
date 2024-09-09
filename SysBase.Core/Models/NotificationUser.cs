namespace SysBase.Core.Models
{
    public class NotificationUser
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public string UserId { get; set; }
        public DateTime? ReadDate { get; set; }
        public bool Visibility { get; set; }
        public Notification Notification { get; set; }
    }
}

