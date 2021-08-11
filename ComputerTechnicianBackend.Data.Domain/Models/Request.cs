using System;

namespace ComputerTechnicianBackend.Data.Domain.Models
{
    public class Request : KeyedEntityBase
    {
        public string Address { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
