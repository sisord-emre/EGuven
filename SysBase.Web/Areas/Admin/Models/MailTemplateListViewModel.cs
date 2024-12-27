using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    internal class MailTemplateListViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public List<MailTemplateLanguageInfo> MailTemplateLanguageInfos { get; set; }
    }
}