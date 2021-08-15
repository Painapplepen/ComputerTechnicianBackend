using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerTechnicianBackend.API.Contracts.IncomingOutgoing
{
    public class OrderDTO
    {
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderTime { get; set; }
    }
}
