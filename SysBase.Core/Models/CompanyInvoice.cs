using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SysBase.Core.Models
{
    public class CompanyInvoice : BaseEntity
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string FullAddress { get; set; }
        public Company Company { get; set; }
        //public List<Project> Projects { get; set; }
    }
}
