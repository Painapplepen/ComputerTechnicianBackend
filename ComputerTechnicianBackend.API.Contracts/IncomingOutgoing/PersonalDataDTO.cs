using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerTechnicianBackend.API.Contracts.IncomingOutgoing
{
    public class PersonalDataDTO
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long CityId { get; set; }
        public string Phone { get; set; }
        public string CreditCards { get; set; }
        public string Email { get; set; }
    }
}
