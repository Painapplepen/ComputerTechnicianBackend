namespace ComputerTechnicianBackend.Data.Domain.Models
{
    public class ProductBasket : KeyedEntityBase
    {
        public Product Product { get; set; }
        public long ProductId { get; set; }
        public Basket Basket { get; set; }
        public long BasketId { get; set; }
    }
}
