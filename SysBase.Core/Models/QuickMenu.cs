﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SysBase.Core.Models
{
    public class QuickMenu
    {
        public int Id { get; set; }
        public int? LanguageId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int Sequence { get; set; }
        public bool Status { get; set; }
        public Language Language { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//sadece insert ederken çalış
        public DateTime CreatedDate { get; set; } = DateTime.Now;//otomatik olarak tarih atar
    }
}
