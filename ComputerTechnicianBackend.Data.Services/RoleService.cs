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
    public interface IRoleService : IBaseService<Role>
    {
    }

    public class RoleService : BaseService<Role>, IRoleService
    {
        private readonly ComputerTechnicianDbContext dbContext;
        public RoleService(ComputerTechnicianDbContext dbContext) : base(dbContext) { }
    }
}
