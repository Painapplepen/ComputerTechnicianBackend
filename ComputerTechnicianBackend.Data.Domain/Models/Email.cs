namespace ComputerTechnicianBackend.Data.Domain.Models
{
    public class Email : KeyedEntityBase
    {
        public string Name { get; set; }
        public PersonalData PersonalData { get; set; }
        public long PersonalDataId { get; set; }
    }
}
