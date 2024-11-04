using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SysBase.Core.Models
{
    public class AnnouncementLanguageInfo: BaseEntityMultiLanguage
    {
        public int AnnouncementId { get; set; }
        public string Description { get; set; }
        public Announcement Announcement { get; set; }
    }
}
