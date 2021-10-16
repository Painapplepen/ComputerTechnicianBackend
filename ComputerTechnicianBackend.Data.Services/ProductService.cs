using ComputerTechnicianBackend.API.Contracts.Incoming.SearchConditions;
using ComputerTechnicianBackend.Data.Domain.Models;
using ComputerTechnicianBackend.Data.EF.SQL;
using ComputerTechnicianBackend.Data.Services.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ComputerTechnicianBackend.Data.Services.Extensions;

namespace ComputerTechnicianBackend.Data.Services
{
    public interface IProductService : IBaseService<Product>
    {
        Task<IReadOnlyCollection<Product>> FindAsync(ProductSearchCondition searchCondition, string sortProperty);
        Task<long> CountAsync(ProductSearchCondition searchCondition);
        Task<bool> ExistsAsync(long id, CancellationToken cancellationToken);
    }
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly ComputerTechnicianDbContext dbContext;

        public ProductService(ComputerTechnicianDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<bool> ExistsAsync(long id, CancellationToken cancellationToken)
        {
            return dbContext.Products.AnyAsync(entity => entity.Id == id, cancellationToken);
        }

        public async Task<IReadOnlyCollection<Product>> FindAsync(ProductSearchCondition searchCondition,
           string sortProperty)
        {
            IQueryable<Product> query = BuildFindQuery(searchCondition);

            query = searchCondition.SortDirection == "asc"
                ? query.OrderBy(sortProperty)
                : query.OrderByDescending(sortProperty);

            return await query.Page(searchCondition.PageSize, searchCondition.Page).ToListAsync();
        }

        public async Task<long> CountAsync(ProductSearchCondition searchCondition)
        {
            IQueryable<Product> query = BuildFindQuery(searchCondition);

            var count = await query.LongCountAsync();

            return count;
        }

        private IQueryable<Product> BuildFindQuery(ProductSearchCondition searchCondition)
        {
            IQueryable<Product> query = dbContext.Products;

            if (searchCondition.Name.Any())
            {
                foreach (var name in searchCondition.Name)
                {
                    var upperName = name.ToUpper().Trim();
                    query = query.Where(x =>
                        x.Name != null && x.Name.ToUpper().Contains(upperName));
                }
            }

            if (searchCondition.Processor.Any())
            {
                foreach (var processor in searchCondition.Processor)
                {
                    var upperProcessor = processor.ToUpper().Trim();
                    query = query.Where(x =>
                        x.Processor != null && x.Processor.ToUpper().Contains(upperProcessor));
                }
            }

            if (searchCondition.VidioCard.Any())
            {
                foreach (var vidioCard in searchCondition.VidioCard)
                {
                    var upperVidioCard = vidioCard.ToUpper().Trim();
                    query = query.Where(x =>
                        x.VidioCard != null && x.VidioCard.ToUpper().Contains(upperVidioCard));
                }
            }

            if (searchCondition.MemoryCapacity != null)
            {
                foreach (var memoryCapacity in searchCondition.MemoryCapacity)
                {
                    query = query.Where(x => x.MemoryCapacity == memoryCapacity);
                }
            }

            if (searchCondition.DriveConfiguration.Any())
            {
                foreach (var driveConfiguration in searchCondition.DriveConfiguration)
                {
                    var upperDriveConfiguration = driveConfiguration.ToUpper().Trim();
                    query = query.Where(x =>
                        x.DriveConfiguration != null && x.DriveConfiguration.ToUpper().Contains(upperDriveConfiguration));
                }
            }

            if (searchCondition.ScreenDiagonal != null)
            {
                foreach (var screenDiagonal in searchCondition.ScreenDiagonal)
                {
                    query = query.Where(x => x.ScreenDiagonal == screenDiagonal);
                }
            }

            if (searchCondition.ScreenResolution.Any())
            {
                foreach (var screenResolution in searchCondition.ScreenResolution)
                {
                    var upperScreenResolution = screenResolution.ToUpper().Trim();
                    query = query.Where(x =>
                        x.ScreenResolution != null &&
                        x.ScreenResolution.ToUpper().Contains(upperScreenResolution));
                }
            }

            if (searchCondition.Cost != null)
            {
                foreach (var cost in searchCondition.Cost)
                {
                    query = query.Where(x => x.Cost == cost);
                }
            }

            if (searchCondition.Amount != null)
            {
                foreach (var amount in searchCondition.Amount)
                {
                    query = query.Where(x => x.Amount == amount);
                }
            }

            if (searchCondition.InStock != null)
            {
                foreach (var inStock in searchCondition.InStock)
                {
                    query = query.Where(x => x.InStock == inStock);
                }
            }

            return query;
        }
    }
}
