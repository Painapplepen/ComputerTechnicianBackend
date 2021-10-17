using ComputerTechnicianBackend.Data.Domain.Models;
using ComputerTechnicianBackend.Data.EF.SQL;
using ComputerTechnicianBackend.Data.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerTechnicianBackend.Data.Services
{
    public interface ICreditCardService : IBaseService<CreditCard>
    {
    }

    public class CreditCardService : BaseService<CreditCard>, ICreditCardService
    {
        private readonly ComputerTechnicianDbContext dbContext;
        public CreditCardService(ComputerTechnicianDbContext dbContext) : base(dbContext) { }
    }
}
