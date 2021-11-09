using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerTechnicianBackend.API.Contracts.Outgoing
{
    public class LoginUserDTO
    {
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
