using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SysBase.Core.Models
{
    public class SectorLanguageInfo : BaseEntityMultiLanguage
    {
        public int SectorId { get; set; }
        public string Title { get; set; }   
        public Sector Sector { get; set; }
    }
}
