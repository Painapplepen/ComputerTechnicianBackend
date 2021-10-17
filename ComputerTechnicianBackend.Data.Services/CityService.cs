using ComputerTechnicianBackend.Data.Domain.Models;
using ComputerTechnicianBackend.Data.EF.SQL;
using ComputerTechnicianBackend.Data.Services.Abstraction;

namespace ComputerTechnicianBackend.Data.Services
{
    public interface ICityService : IBaseService<City>
    {
    }

    public class CityService : BaseService<City>, ICityService
    {
        private readonly ComputerTechnicianDbContext dbContext;
        public CityService(ComputerTechnicianDbContext dbContext) : base(dbContext) { }
    }
}
