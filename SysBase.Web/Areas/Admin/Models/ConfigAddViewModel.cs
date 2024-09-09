using Microsoft.AspNetCore.Mvc;
using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    public class ConfigAddViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public Config Config { get; set; }
        public IEnumerable<Language> Languages { get; set; }
    }
}
