using Microsoft.AspNetCore.Mvc;
using SysBase.Core.Models;

namespace SysBase.Web.ViewModels
{
    public class SoftwareCategoryDetailViewModel : UiLayoutViewModel
    {
        public SoftwareCategoryLanguageInfo SoftwareCategoryLanguageInfo { get; set; }
        public List<SoftwareCategoryLanguageInfo> SoftwareCategoryLanguageInfos { get; set; }
    }
}
