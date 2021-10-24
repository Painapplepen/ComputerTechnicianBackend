using ComputerTechnicianBackend.Data.Domain.Views;
using ComputerTechnicianBackend.Data.EF.SQL;
using ComputerTechnicianBackend.Data.Services.Abstraction;

namespace ComputerTechnicianBackend.Data.Services
{
    public interface IPersonalDataViewService : IBaseService<PersonalDataView>
    {
    }

    public class PersonalDataViewService : BaseService<PersonalDataView>, IPersonalDataViewService
    {
        private readonly ComputerTechnicianDbContext dbContext;
        public PersonalDataViewService(ComputerTechnicianDbContext dbContext) : base(dbContext) { }
    }
}
