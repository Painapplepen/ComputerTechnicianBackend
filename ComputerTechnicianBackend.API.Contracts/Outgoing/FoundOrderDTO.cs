using System;

namespace ComputerTechnicianBackend.API.Contracts.Outgoing
{
    public class FoundOrderDTO 
    {
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderTime { get; set; }
    }
}
