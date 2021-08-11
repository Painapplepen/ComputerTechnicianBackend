namespace ComputerTechnicianBackend.Data.Domain.Models
{
    public class ProductManufacture : KeyedEntityBase
    {
        public Manufacture Manufacture { get; set; }
        public long ManufactureId { get; set; }
        public Product Product { get; set; }
        public long ProductId { get; set; }
    }
}
