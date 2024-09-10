using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysBase.Core.Models
{
    public class Project
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool NameHideShow { get; set; }
        public bool NameRequiredField { get; set; }
        public string Surname { get; set; }
        public bool SurnameHideShow { get; set; }
        public bool SurnameRequiredField { get; set; }
        public string DateBirth { get; set; }
        public bool DateBirthHideShow { get; set; }
        public bool DateBirthRequiredField { get; set; }
        public string Nationality { get; set; }
        public bool NationalityHideShow { get; set; }
        public bool NationalityRequiredField { get; set; }
        public string Tckn { get; set; }
        public bool TcknHideShow { get; set; }
        public bool TcknRequiredField { get; set; }
        public string Email { get; set; }
        public bool EmailHideShow { get; set; }
        public bool EmailRequiredField { get; set; }
        public string PlaceBirth { get; set; }
        public bool PlaceBirthHideShow { get; set; }
        public bool PlaceBirthRequiredField { get; set; }
        public string IdentityCardSerialNumber { get; set; }
        public bool IdentityCardSerialNumberHideShow { get; set; }
        public bool IdentityCardSerialNumberRequiredField { get; set; }
        public string SafetyWord { get; set; }
        public bool SafetyWordHideShow { get; set; }
        public bool SafetyWordRequiredField { get; set; }
        public string City { get; set; }
        public bool CityHideShow { get; set; }
        public bool CityRequiredField { get; set; }
        public string County { get; set; }
        public bool CountyHideShow { get; set; }
        public bool CountyRequiredField { get; set; }
        public string Postcode { get; set; }
        public bool PostcodeHideShow { get; set; }
        public bool PostcodeRequiredField { get; set; }
        public string Address { get; set; }
        public bool AddressHideShow { get; set; }
        public bool AddressRequiredField { get; set; }
        public string Phone { get; set; }
        public bool PhoneHideShow { get; set; }
        public bool PhoneRequiredField { get; set; }
        public string Fax { get; set; }
        public bool FaxHideShow { get; set; }
        public bool FaxRequiredField { get; set; }
        public string Gsm { get; set; }
        public bool GsmHideShow { get; set; }
        public bool GsmRequiredField { get; set; }
        public bool Status { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//sadece insert ederken çalış
        public DateTime CreatedDate { get; set; } = DateTime.Now;//otomatik olarak tarih atar
        public Company Company { get; set; }
    }
}
