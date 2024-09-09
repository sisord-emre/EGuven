using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysBase.Core.Models
{
    public class Notification
    {
        public int Id { get; set; }
        [Comment("1:saatlik,2:günlük 3:haftalık,4:aylık;5:tek seferlik")]
        public int Type { get; set; }
        public string Subject { get; set; }
        public string Contents { get; set; }
        public bool Status { get; set; }
        public DateTime ReleaseDate { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//sadece insert ederken çalış
        public DateTime CreatedDate { get; set; } = DateTime.Now;//otomatik olarak tarih atar
        public List<NotificationUser> NotificationUsers { get; set; }
        public List<AppUser> AppUserList { get; set; }
    }
}
