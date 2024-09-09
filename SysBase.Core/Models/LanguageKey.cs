using Microsoft.EntityFrameworkCore;

namespace SysBase.Core.Models
{
    public class LanguageKey
    {
        public int Id { get; set; }
        public string Code { get; set; }
        [Comment("1:Site,2:Admin")]
        public int Type { get; set; }
        public List<LanguageValue> LanguageValues { get; set; }
    }
}
