using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysBase.Core.Models
{
    public class Project
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Code { get; set; }
        public bool Status { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//sadece insert ederken çalış
        public DateTime CreatedDate { get; set; } = DateTime.Now;//otomatik olarak tarih atar
        public Company Company { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime EndDate { get; set; }
        public string Image { get; set; }
        public bool PaymetForm { get; set; }
        public bool InvoiceInfoIsVisible { get; set; }
        public int? CompanyInvoiceId { get; set; }
        //public CompanyInvoice CompanyInvoice { get; set; }
        public List<ProjectProduct> ProjectProducts { get; set; }
        public List<ProjectField> ProjectFields { get; set; }
        public List<ProjectLanguageInfo> ProjectLanguageInfos { get; set; }
    }
}
