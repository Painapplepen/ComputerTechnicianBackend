using ComputerTechnicianBackend.Data.Domain.Models;
using ComputerTechnicianBackend.Data.EF.SQL;
using ComputerTechnicianBackend.Data.Services.Abstraction;

namespace ComputerTechnicianBackend.Data.Services
{
    public interface IPhoneService : IBaseService<Phone>
    {
    }

    public class PhoneService : BaseService<Phone>, IPhoneService
    {
        private readonly ComputerTechnicianDbContext dbContext;
        public PhoneService(ComputerTechnicianDbContext dbContext) : base(dbContext) { }
    }
}
