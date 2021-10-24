using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerTechnicianBackend.Data.Domain.Views
{
    public class PersonalDataView : KeyedEntityBase
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public long CardNumber { get; set; }
        public string EpirationDate { get; set; }
    }
}
