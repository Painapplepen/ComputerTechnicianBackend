namespace ComputerTechnicianBackend.Data.Domain.Models
{
    public class OrderProductManufacture : KeyedEntityBase
    {
        public long Amount { get; set; }
        public Order Orders { get; set; }
        public long OrderId { get; set; }
        public ProductManufacture ProductManufacture { get; set; }
        public long ProductManufactureId { get; set; }
    }
}
