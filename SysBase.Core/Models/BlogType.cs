using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysBase.Core.Models
{
    public class BlogType : BaseEntity
    {
        public int LanguageId { get; set; }
        public string Title { get; set; }
        public int Sequence { get; set; }
        public List<Blog> Blogs { get; set; }
        public Language Language { get; set; }
    }
}
