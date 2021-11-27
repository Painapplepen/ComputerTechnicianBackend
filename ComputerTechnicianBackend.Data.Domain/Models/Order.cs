using System;

namespace ComputerTechnicianBackend.Data.Domain.Models
{
    public class Order : KeyedEntityBase
    {
        public Manufacture Manufacture { get; set; }
        public long ManufactureId { get; set; }
        public string OrderStatus { get; set; }
        public string OrderDate { get; set; }
        public string OrderTime { get; set; }
    }
}
