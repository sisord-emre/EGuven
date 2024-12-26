namespace SysBase.Core.Models
{
    public class ProjectLanguageInfo : BaseEntityMultiLanguage
    {
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public Project Project { get; set; }
    }
}
