namespace SysBase.Core.Models
{
    public class City
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        //Navigation Property
        public Country Country { get; set; }
        public List<County> Counties { get; set; }
    }
}
