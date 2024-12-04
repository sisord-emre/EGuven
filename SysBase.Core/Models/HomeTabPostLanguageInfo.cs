using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysBase.Core.Models
{
    public class HomeTabPostLanguageInfo : BaseEntityMultiLanguage
    {
        public int HomeTabPostId { get; set; }
        public string Title { get; set; }
        public HomeTabPost HomeTabPost { get; set; }
        public List<HomeTabPostLanguageInfoContent> HomeTabPostLanguageInfoContents { get; set; }
    }
}
