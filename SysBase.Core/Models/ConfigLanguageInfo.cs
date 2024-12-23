using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SysBase.Core.Models
{
    public class ConfigLanguageInfo : BaseEntityMultiLanguage
    {
        public int ConfigId { get; set; }
        public string RemittanceEftInformation { get; set; }
        public Config Config { get; set; }
    }
}
