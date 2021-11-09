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
using ComputerTechnicianBackend.Data.Domain.Views;

namespace ComputerTechnicianBackend.Data.Services
{
    public interface IUserViewService : IBaseService<UserView>
    {
        Task<IReadOnlyCollection<UserView>> FindAsync(UserSearchCondition searchCondition, string sortProperty);
        Task<long> CountAsync(UserSearchCondition searchCondition);
        Task<bool> ExistsAsync(long id, CancellationToken cancellationToken);
    }

    public class UserViewService : BaseService<UserView>, IUserViewService
    {
        private readonly ComputerTechnicianDbContext dbContext;

        public UserViewService(ComputerTechnicianDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<bool> ExistsAsync(long id, CancellationToken cancellationToken)
        {
            return dbContext.Users.AnyAsync(entity => entity.Id == id, cancellationToken);
        }

        public async Task<IReadOnlyCollection<UserView>> FindAsync(UserSearchCondition searchCondition,
           string sortProperty)
        {
            IQueryable<UserView> query = BuildFindQuery(searchCondition);

            query = searchCondition.SortDirection == "asc"
                ? query.OrderBy(sortProperty)
                : query.OrderByDescending(sortProperty);

            return await query.Page(searchCondition.PageSize, searchCondition.Page).ToListAsync();
        }

        public async Task<long> CountAsync(UserSearchCondition searchCondition)
        {
            IQueryable<UserView> query = BuildFindQuery(searchCondition);

            var count = await query.LongCountAsync();

            return (int)Math.Ceiling((double)count / searchCondition.PageSize);
        }

        private IQueryable<UserView> BuildFindQuery(UserSearchCondition searchCondition)
        {
            IQueryable<UserView> query = dbContext.UsersView;

            if (searchCondition.UserName.Any())
            {
                foreach (var userName in searchCondition.UserName)
                {
                    var upperUserName = userName.ToUpper().Trim();
                    query = query.Where(x =>
                        x.UserName != null && x.UserName.ToUpper().Contains(upperUserName));
                }
            }

            if (searchCondition.Email.Any())
            {
                foreach (var email in searchCondition.Email)
                {
                    var upperEmail = email.ToUpper().Trim();
                    query = query.Where(x =>
                        x.Email != null && x.Email.ToUpper().Contains(upperEmail));
                }
            }

            if (searchCondition.Role.Any())
            {
                foreach (var role in searchCondition.Role)
                {
                    var upperRole = role.ToUpper().Trim();
                    query = query.Where(x =>
                        x.Role != null && x.Role.ToUpper().Contains(upperRole));
                }
            }

            if (searchCondition.BasketSize != null)
            {
                foreach (var basketSize in searchCondition.BasketSize)
                {
                    query = query.Where(x => x.BasketSize == basketSize);
                }
            }

            return query;
        }
    }
}
