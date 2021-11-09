using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerTechnicianBackend.Data.Domain.Models
{
    public class Basket : KeyedEntityBase
    {
        [ForeignKey("User")]
        public long UserId { get; set; }
        public User User { get; set; }
        public long? Amount { get; set; }
    }
}
