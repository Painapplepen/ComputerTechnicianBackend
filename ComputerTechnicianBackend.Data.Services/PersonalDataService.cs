using ComputerTechnicianBackend.Data.Domain.Models;
using ComputerTechnicianBackend.Data.EF.SQL;
using ComputerTechnicianBackend.Data.Services.Abstraction;

namespace ComputerTechnicianBackend.Data.Services
{
    public interface IPersonalDataService : IBaseService<PersonalData>
    {
    }

    public class PersonalDataService : BaseService<PersonalData>, IPersonalDataService
    {
        private readonly ComputerTechnicianDbContext dbContext;
        public PersonalDataService(ComputerTechnicianDbContext dbContext) : base(dbContext) { }
    }
}
