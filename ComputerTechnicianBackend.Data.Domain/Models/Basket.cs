using System.Collections.Generic;

namespace ComputerTechnicianBackend.Data.Domain.Models
{
    public class Basket : KeyedEntityBase
    {
        public long Amount { get; set; }
        public IList<ProductBasket> ProductBaskets { get; set; } = new List<ProductBasket>();
    }
}
