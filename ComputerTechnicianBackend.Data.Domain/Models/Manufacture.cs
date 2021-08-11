namespace ComputerTechnicianBackend.Data.Domain.Models
{
    public class Manufacture : KeyedEntityBase
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
    }
}
