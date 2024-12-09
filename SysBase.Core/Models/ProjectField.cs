namespace SysBase.Core.Models
{
    public class ProjectField
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int FieldId { get; set; }
        public bool Visible { get; set; }
        public bool Required { get; set; }
        public Project Project { get; set; }
        public Field Field { get; set; }
    }
}
