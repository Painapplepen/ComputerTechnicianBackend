namespace ComputerTechnicianBackend.Data.Domain.Models
{
    public class RequestOrder : KeyedEntityBase
    {
        public Order Orders { get; set; }
        public long OrderId { get; set; }
        public Request Request { get; set; }
        public long RequestId { get; set; }
    }
}
