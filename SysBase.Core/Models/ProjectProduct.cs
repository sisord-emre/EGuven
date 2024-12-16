namespace SysBase.Core.Models
{
    public class ProjectProduct
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int ProductId { get; set; }
        public decimal Amount { get; set; }
        public Project Project { get; set; }
        public Product Product { get; set; }
        public List<ApiBasvuruRequest> ApiBasvuruRequests { get; set; }
    }
}
