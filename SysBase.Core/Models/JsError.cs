using System.ComponentModel.DataAnnotations.Schema;

namespace SysBase.Core.Models
{
    public class JsError
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int Line { get; set; }
        public string Error { get; set; }
        public int AppUserId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//sadece insert ederken çalış
        public DateTime CreatedDate { get; set; } = DateTime.Now;//otomatik olarak tarih atar
    }
}
