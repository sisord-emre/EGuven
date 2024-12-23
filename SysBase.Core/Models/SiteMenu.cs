﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysBase.Core.Models
{
    public class SiteMenu
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int? LanguageId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int Sequence { get; set; }
        public bool Status { get; set; }
        public string Icon { get; set; }
        public Language Language { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//sadece insert ederken çalış
        public DateTime CreatedDate { get; set; } = DateTime.Now;//otomatik olarak tarih atar
    }
}
