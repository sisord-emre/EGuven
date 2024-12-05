using System.ComponentModel.DataAnnotations.Schema;

namespace SysBase.Core.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CorporateSalesRepresentative { get; set; }
        public string OperationRepresentative { get; set; }
        public bool Status { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//sadece insert ederken çalış
        public DateTime CreatedDate { get; set; } = DateTime.Now;//otomatik olarak tarih atar
        public List<Project> Projects { get; set; }
        public List<CompanyInvoice> CompanyInvoices { get; set; }
    }
}
