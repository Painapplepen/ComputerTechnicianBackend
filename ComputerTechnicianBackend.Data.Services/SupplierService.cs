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
    public interface ISupplierService : IBaseService<Supplier>
    {
        Task<IReadOnlyCollection<Supplier>> FindAsync(SupplierSearchCondition searchCondition, string sortProperty);
        Task<long> CountAsync(SupplierSearchCondition searchCondition);
        Task<bool> ExistsAsync(long id, CancellationToken cancellationToken);
    }

    public class SupplierService : BaseService<Supplier>, ISupplierService
    {
        private readonly ComputerTechnicianDbContext dbContext;

        public SupplierService(ComputerTechnicianDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<bool> ExistsAsync(long id, CancellationToken cancellationToken)
        {
            return dbContext.Suppliers.AnyAsync(entity => entity.Id == id, cancellationToken);
        }

        public async Task<IReadOnlyCollection<Supplier>> FindAsync(SupplierSearchCondition searchCondition,
           string sortProperty)
        {
            IQueryable<Supplier> query = BuildFindQuery(searchCondition);

            query = searchCondition.SortDirection == "asc"
                ? query.OrderBy(sortProperty)
                : query.OrderByDescending(sortProperty);

            return await query.Page(searchCondition.PageSize, searchCondition.Page).ToListAsync();
        }

        public async Task<long> CountAsync(SupplierSearchCondition searchCondition)
        {
            IQueryable<Supplier> query = BuildFindQuery(searchCondition);

            var count = await query.LongCountAsync();

            return count;
        }

        private IQueryable<Supplier> BuildFindQuery(SupplierSearchCondition searchCondition)
        {
            IQueryable<Supplier> query = dbContext.Suppliers;

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
