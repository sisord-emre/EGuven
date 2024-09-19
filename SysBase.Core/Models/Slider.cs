using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysBase.Core.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Media { get; set; }
        public string Common { get ; set; }
        public int Sequence { get; set; }
        public bool Status { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//sadece insert ederken çalış
        public DateTime CreatedDate { get; set; } = DateTime.Now;//otomatik olarak tarih atar
    }
}
