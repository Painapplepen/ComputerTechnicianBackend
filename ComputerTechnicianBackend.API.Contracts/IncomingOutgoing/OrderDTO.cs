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
        public string OrderDate { get; set; }
        public string OrderTime { get; set; }
        public long ManufactureId { get; set; }
    }
}
