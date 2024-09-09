namespace SysBase.Core.DTOs
{
    public class MenuDto
    {
        public int Id { get; set; }
        public string ControllerName { get; set; }
        public string TableName { get; set; }
        public string TablePrimaryColumn { get; set; }
        public int UpMenuId { get; set; }
        public string Name { get; set; }
        public string Page { get; set; }
        public int Sequence { get; set; }
        public string Icon { get; set; }
        public string VideoUrl { get; set; }
    }
}
