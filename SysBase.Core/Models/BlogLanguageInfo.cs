﻿using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SysBase.Core.Models
{
    public class BlogLanguageInfo : BaseEntityMultiLanguage
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        public Blog Blog { get; set; }
    }
}
