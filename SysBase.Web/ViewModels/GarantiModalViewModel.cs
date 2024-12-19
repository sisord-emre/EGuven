using SysBase.Core.Models;

namespace SysBase.Web.ViewModels
{
    public class GarantiModalViewModel
    {
        public ApiBasvuruRequest ApiBasvuruRequest { get; set; }
        public string dateMonth { get; set; }
        public string dateYear { get; set; }
        public string cardAdSoyad { get; set; }
        public string cardNo { get; set; }
        public string code { get; set; }
        public string Hash { get; set; }
        public string IpAdresi { get; set; }
    }
}
