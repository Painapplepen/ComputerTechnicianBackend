using System;

namespace ComputerTechnicianBackend.Data.Domain.Models
{
    public class PersonalData : KeyedEntityBase
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string DateOfBirth { get; set; }
        public City Cities { get; set; }
        public long? CityId { get; set; }
        public CreditCard CreditCards { get; set; }
        public long? CreditCardId { get; set; }
        public Phone Phones { get; set; }
        public long? PhoneId { get; set; }
    }
}
