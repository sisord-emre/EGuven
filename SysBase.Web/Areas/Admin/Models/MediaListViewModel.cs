using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    internal class MediaListViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public List<Media> Medias { get; set; }
    }
}