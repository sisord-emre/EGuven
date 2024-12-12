namespace SysBase.Core.Models
{
    public class Field : BaseEntity
    {
        public int FieldGroupId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string ApiColumn { get; set; }
        public int Sequence { get; set; }
        public FieldGroup FieldGroup { get; set; }
        public List<ProjectField> ProjectFields { get; set; }
    }
}
