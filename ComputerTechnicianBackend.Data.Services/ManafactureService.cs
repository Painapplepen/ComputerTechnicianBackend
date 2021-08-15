using ComputerTechnicianBackend.API.Contracts.Incoming.SearchConditions;
using ComputerTechnicianBackend.Data.Domain.Models;
using ComputerTechnicianBackend.Data.EF.SQL;
using ComputerTechnicianBackend.Data.Services.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ComputerTechnicianBackend.Data.Services.Extensions;

namespace ComputerTechnicianBackend.Data.Services
{
    public interface IManafactureService : IBaseService<Manufacture>
    {
        Task<IReadOnlyCollection<Manufacture>> FindAsync(ManafactureSearchCondition searchCondition, string sortProperty);
        Task<long> CountAsync(ManafactureSearchCondition searchCondition);
        Task<bool> ExistsAsync(long id, CancellationToken cancellationToken);
    }

    public class ManafactureService : BaseService<Manufacture>, IManafactureService
    {
        private readonly ComputerTechnicianDbContext dbContext;

        public ManafactureService(ComputerTechnicianDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<bool> ExistsAsync(long id, CancellationToken cancellationToken)
        {
            return dbContext.Manufactures.AnyAsync(entity => entity.Id == id, cancellationToken);
        }

        public async Task<IReadOnlyCollection<Manufacture>> FindAsync(ManafactureSearchCondition searchCondition,
           string sortProperty)
        {
            IQueryable<Manufacture> query = BuildFindQuery(searchCondition);

            query = searchCondition.SortDirection == "asc"
                ? query.OrderBy(sortProperty)
                : query.OrderByDescending(sortProperty);

            return await query.Page(searchCondition.PageSize, searchCondition.Page).ToListAsync();
        }

        public async Task<long> CountAsync(ManafactureSearchCondition searchCondition)
        {
            IQueryable<Manufacture> query = BuildFindQuery(searchCondition);

            var count = await query.LongCountAsync();

            return count % 10 == 0 ? count / 10 : count / 10 + 1;
        }

        private IQueryable<Manufacture> BuildFindQuery(ManafactureSearchCondition searchCondition)
        {
            IQueryable<Manufacture> query = dbContext.Manufactures;

            if (searchCondition.Address.Any())
            {
                foreach (var address in searchCondition.Address)
                {
                    var upperAddress = address.ToUpper().Trim();
                    query = query.Where(x =>
                        x.Address != null && x.Address.ToUpper().Contains(upperAddress));
                }
            }

            if (searchCondition.City.Any())
            {
                foreach (var city in searchCondition.City)
                {
                    var upperCity = city.ToUpper().Trim();
                    query = query.Where(x =>
                        x.City != null && x.City.ToUpper().Contains(upperCity));
                }
            }

            if (searchCondition.Country.Any())
            {
                foreach (var country in searchCondition.Country)
                {
                    var upperCountry = country.ToUpper().Trim();
                    query = query.Where(x =>
                        x.Country != null && x.Country.ToUpper().Contains(upperCountry));
                }
            }

            if (searchCondition.Name.Any())
            {
                foreach (var name in searchCondition.Name)
                {
                    var upperName = name.ToUpper().Trim();
                    query = query.Where(x =>
                        x.Name != null && x.Name.ToUpper().Contains(upperName));
                }
            }

            return query;
        }
    }
}
