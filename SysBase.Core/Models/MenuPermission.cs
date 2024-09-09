namespace SysBase.Core.Models
{
    public class MenuPermission
    {
        public int MenuId { get; set; }
        public string ControllerName { get; set; }
        public bool List { get; set; }
        public bool Add { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public bool Export { get; set; }
    }
}
