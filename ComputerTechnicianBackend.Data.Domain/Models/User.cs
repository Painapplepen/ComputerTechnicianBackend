namespace ComputerTechnicianBackend.Data.Domain.Models
{
    public class User : KeyedEntityBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public PersonalData PersonalData { get; set; }
        public long PersonalDataId { get; set; }
        public Role Roles { get; set; }
        public long RoleId { get; set; }
        public Basket Basket { get; set; }
        public long BasketId { get; set; }
        public string Eamil { get; set; }
    }
}
