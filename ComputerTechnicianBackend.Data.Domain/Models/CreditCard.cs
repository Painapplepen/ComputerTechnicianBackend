namespace ComputerTechnicianBackend.Data.Domain.Models
{
    public class CreditCard : KeyedEntityBase
    {
        public long CardNumber { get; set; }
        public string EpirationDate { get; set; }
     }
}
