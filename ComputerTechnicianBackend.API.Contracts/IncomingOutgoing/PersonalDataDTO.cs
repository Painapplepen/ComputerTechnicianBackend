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
        public string DateOfBirth { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public long CardNumber { get; set; }
        public string EpirationDate { get; set; }
    }
}
