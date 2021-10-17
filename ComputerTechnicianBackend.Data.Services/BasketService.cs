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
    public interface IBasketService : IBaseService<Basket>
    {
    }

    public class BasketService : BaseService<Basket>, IBasketService
    {
        private readonly ComputerTechnicianDbContext dbContext;
        public BasketService(ComputerTechnicianDbContext dbContext) : base(dbContext) { }
    }
}
