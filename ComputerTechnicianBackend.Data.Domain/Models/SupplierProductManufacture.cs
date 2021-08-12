namespace ComputerTechnicianBackend.Data.Domain.Models
{
    public class SupplierProductManufacture : KeyedEntityBase
    {
        public long Cost { get; set; }
        public long Amount { get; set; }
        public ProductManufacture ProductManufacture { get; set; }
        public long ProductManufactureId { get; set; }
        public Supplier Supplier { get; set; }
        public long SupplierId { get; set; }
    }
}
