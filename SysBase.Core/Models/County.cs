namespace SysBase.Core.Models
{
    public class County
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        //Navigation Property
        public City City { get; set; }
    }
}
