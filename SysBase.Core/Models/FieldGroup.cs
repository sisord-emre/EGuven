namespace SysBase.Core.Models
{
    public class FieldGroup : BaseEntity
    {
        public int UpId { get; set; }
        public int Title { get; set; }
        public int Sequence { get; set; }
        public List<Field> Fields { get; set; }
    }
}
