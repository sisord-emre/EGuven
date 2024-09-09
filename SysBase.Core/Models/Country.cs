using System.ComponentModel.DataAnnotations;

namespace SysBase.Core.Models
{
    public class Country
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Code { get; set; }
        public string PhoneCode { get; set; }
        public bool Status { get; set; }
        public List<City> Cities { get; set; }
    }
}
