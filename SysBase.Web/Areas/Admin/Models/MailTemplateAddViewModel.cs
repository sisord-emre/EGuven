using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    internal class MailTemplateAddViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public MailTemplate MailTemplate { get; set; }
        public IEnumerable<Language> Languages { get; set; }
        public int MaxSequence { get; set; }
    }
}