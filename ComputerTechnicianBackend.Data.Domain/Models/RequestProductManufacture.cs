namespace ComputerTechnicianBackend.Data.Domain.Models
{
    public class RequestProductManufacture : KeyedEntityBase
    {
        public long Amount { get; set; }
        public ProductManufacture ProductManufacture { get; set; }
        public long ProductManufactureId { get; set; }
        public Request Request { get; set; }
        public long RequestId { get; set; }
    }
}
