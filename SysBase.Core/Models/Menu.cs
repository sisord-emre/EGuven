using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysBase.Core.Models
{
    public class Menu
    {
        public int Id { get; set; }
        [Required]
        public string ControllerName { get; set; }
        public string TableName { get; set; }
        public string TablePrimaryColumn { get; set; }
        public int UpMenuId { get; set; }
        public string Name { get; set; }
        public string Page { get; set; }
        public bool Visibility { get; set; }
        [Comment("burdan kapatılırsa menu güncelleme ekranındada çıkmaz")]
        public bool SpecialVisibility { get; set; }
        public int Sequence { get; set; }
        //[Column(TypeName = "Nvarchar(50)")]
        public string Icon { get; set; }
        [Comment("0 ise ana menulerden 1 ise kayit 2 ise listeleme eğer farklı tipte bir menu eklenecek ise tipi 3 olacak")]
        public int Type { get; set; }
        public string VideoUrl { get; set; }
        public int BaseMenuId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//sadece insert ederken çalış
        public DateTime CreatedDate { get; set; } = DateTime.Now;//otomatik olarak tarih atar
    }
}
