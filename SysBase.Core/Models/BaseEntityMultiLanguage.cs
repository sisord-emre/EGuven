using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysBase.Core.Models
{
    public abstract class BaseEntityMultiLanguage
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public bool Status { get; set; }
        public Language Language { get; set; }
    }
}
