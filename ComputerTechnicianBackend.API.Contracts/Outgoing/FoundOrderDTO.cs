using System;

namespace ComputerTechnicianBackend.API.Contracts.Outgoing
{
    public class FoundOrderDTO 
    {
        public long Id { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderTime { get; set; }
    }
}
