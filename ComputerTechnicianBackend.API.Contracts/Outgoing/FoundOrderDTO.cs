using System;

namespace ComputerTechnicianBackend.API.Contracts.Outgoing
{
    public class FoundOrderDTO 
    {
        public long Id { get; set; }
        public string OrderStatus { get; set; }
        public string OrderDate { get; set; }
        public string OrderTime { get; set; }
    }
}
