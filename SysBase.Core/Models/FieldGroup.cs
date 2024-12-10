namespace SysBase.Core.Models
{
    public class FieldGroup : BaseEntity
    {
        public int UpId { get; set; }
        public string Title { get; set; }
        public int Sequence { get; set; }
        public List<Field> Fields { get; set; }
    }
}
