using ComputerTechnicianBackend.API.Contracts.Incoming.SearchConditions;
using ComputerTechnicianBackend.Data.Domain.Models;
using ComputerTechnicianBackend.Data.EF.SQL;
using ComputerTechnicianBackend.Data.Services.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ComputerTechnicianBackend.Data.Services.Extensions;
using System.Linq;

namespace ComputerTechnicianBackend.Data.Services
{
    public interface IOrderService : IBaseService<Order>
    {
        Task<IReadOnlyCollection<Order>> FindAsync(OrderSearchCondition searchCondition, string sortProperty);
        Task<long> CountAsync(OrderSearchCondition searchCondition);
        Task<bool> ExistsAsync(long id, CancellationToken cancellationToken);
    }

    class OrderService : BaseService<Order>, IOrderService
    {
        private readonly ComputerTechnicianDbContext dbContext;

        public OrderService(ComputerTechnicianDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<bool> ExistsAsync(long id, CancellationToken cancellationToken)
        {
            return dbContext.Orders.AnyAsync(entity => entity.Id == id, cancellationToken);
        }

        public async Task<IReadOnlyCollection<Order>> FindAsync(OrderSearchCondition searchCondition,
           string sortProperty)
        {
            IQueryable<Order> query = BuildFindQuery(searchCondition);

            query = searchCondition.SortDirection == "asc"
                ? query.OrderBy(sortProperty)
                : query.OrderByDescending(sortProperty);

            return await query.Page(searchCondition.PageSize, searchCondition.Page).ToListAsync();
        }

        public async Task<long> CountAsync(OrderSearchCondition searchCondition)
        {
            IQueryable<Order> query = BuildFindQuery(searchCondition);

            var count = await query.LongCountAsync();

            return (int)Math.Ceiling((double)count / searchCondition.PageSize);
        }

        private IQueryable<Order> BuildFindQuery(OrderSearchCondition searchCondition)
        {
            IQueryable<Order> query = dbContext.Orders;

            if (searchCondition.OrderStatus.Any())
            {
                foreach (var orderStatus in searchCondition.OrderStatus)
                {
                    var upperOrderStatus = orderStatus.ToUpper().Trim();
                    query = query.Where(x =>
                        x.OrderStatus != null && x.OrderStatus.ToUpper().Contains(upperOrderStatus));
                }
            }

            return query;
        }
    }
}
