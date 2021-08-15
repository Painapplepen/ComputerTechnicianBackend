using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerTechnicianBackend.API.Contracts.IncomingOutgoing
{
    public class SupplierDTO
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
    }
}
