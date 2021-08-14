using ComputerTechnicianBackend.API.Contracts.Incoming.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerTechnicianBackend.API.Contracts.Incoming.SearchConditions
{
    public class OrderSearchCondition : PagedDTOBase
    {
        public string[] OrderStatus { get; set; }
    }
}
