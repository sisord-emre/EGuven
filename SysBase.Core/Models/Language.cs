using System.ComponentModel.DataAnnotations.Schema;

namespace SysBase.Core.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
        public bool AdminStatus { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//sadece insert ederken çalış
        public DateTime CreatedDate { get; set; } = DateTime.Now;//otomatik olarak tarih atar
        public List<LanguageValue> LanguageValues { get; set; }
    }
}
