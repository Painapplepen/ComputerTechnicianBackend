namespace ComputerTechnicianBackend.Data.Domain.Models
{
    public class OrderProduct : KeyedEntityBase
    {
        public long Amount { get; set; }
        public Order Order { get; set; }
        public long OrderId { get; set; }
        public Product Product { get; set; }
        public long ProductId { get; set; }
    }
}
