using ComputerTechnicianBackend.API.Application.Commands.Abstractions;
using ComputerTechnicianBackend.API.Application.Queries.Abstractions;
using ComputerTechnicianBackend.API.Contracts.Incoming.SearchConditions;
using ComputerTechnicianBackend.API.Contracts.IncomingOutgoing;
using ComputerTechnicianBackend.API.Contracts.Outgoing;
using ComputerTechnicianBackend.API.Contracts.Outgoing.Abstractions;
using ComputerTechnicianBackend.Data.Domain.Models;
using ComputerTechnicianBackend.Data.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ComputerTechnicianBackend.API.Application.Queries.ProductQueries
{
    public class SearchProductQuery : PagedSearchQuery<FoundProductDTO, ProductSearchCondition>
    {
        public SearchProductQuery(ProductSearchCondition searchCondition) : base(searchCondition)
        { }
    }

    public class SearchProductQueryHandler : IRequestHandler<SearchProductQuery, PagedResponse<FoundProductDTO>>
    {
        private readonly IProductService productService;

        public SearchProductQueryHandler(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<PagedResponse<FoundProductDTO>> Handle(SearchProductQuery request, CancellationToken cancellationToken)
        {
            var searchCondition = new ProductSearchCondition()
            {
                Name = GetFilterValues(request.SearchCondition.Name),
                Processor = GetFilterValues(request.SearchCondition.Processor),
                VidioCard = GetFilterValues(request.SearchCondition.VidioCard),
                MemoryCapacity = request.SearchCondition.MemoryCapacity,
                DriveConfiguration = GetFilterValues(request.SearchCondition.DriveConfiguration),
                ScreenDiagonal = request.SearchCondition.ScreenDiagonal,
                Cost = request.SearchCondition.Cost,
                Amount = request.SearchCondition.Amount,
                InStock = request.SearchCondition.InStock,
                Page = request.SearchCondition.Page,
                PageSize = request.SearchCondition.PageSize,
                SortDirection = request.SearchCondition.SortDirection,
                SortProperty = request.SearchCondition.SortProperty
            };

            var sortProperty = GetSortProperty(searchCondition.SortProperty);
            IReadOnlyCollection<Product> foundProduct = await productService.FindAsync(searchCondition, sortProperty);
            FoundProductDTO[] mappedProduct = foundProduct.Select(MapToFoundProductDTO).ToArray();
            var totalCount = await productService.CountAsync(searchCondition);

            return new PagedResponse<FoundProductDTO>
            {
                Items = mappedProduct,
                TotalCount = totalCount
            };
        }

        private FoundProductDTO MapToFoundProductDTO(Product product)
        {
            return new FoundProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Processor = product.Processor,
                VidioCard = product.VidioCard,
                MemoryCapacity = product.MemoryCapacity,
                DriveConfiguration = product.DriveConfiguration,
                ScreenDiagonal = product.ScreenDiagonal,
                ScreenResolution = product.ScreenResolution,
                Cost = product.Cost,
                Amount = product.Amount,
                InStock = product.InStock
            };
        }

        private string[] GetFilterValues(ICollection<string> values)
        {
            return values == null
                       ? Array.Empty<string>()
                       : values.Select(v => v.Trim()).Distinct().ToArray();
        }

        protected string GetSortProperty(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                return nameof(Product.Id);
            }
            else if (propertyName.Equals("name", StringComparison.InvariantCultureIgnoreCase))
            {
                return nameof(Product.Name);
            }
            else if (propertyName.Equals("releaseDate", StringComparison.InvariantCultureIgnoreCase))
            {
                return nameof(Product.ReleaseDate);
            }
            else if (propertyName.Equals("processor", StringComparison.InvariantCultureIgnoreCase))
            {
                return nameof(Product.Processor);
            }
            else if (propertyName.Equals("vidioCard", StringComparison.InvariantCultureIgnoreCase))
            {
                return nameof(Product.VidioCard);
            }
            else if (propertyName.Equals("memoryCapacity", StringComparison.InvariantCultureIgnoreCase))
            {
                return nameof(Product.MemoryCapacity);
            }
            else if (propertyName.Equals("driveConfiguration", StringComparison.InvariantCultureIgnoreCase))
            {
                return nameof(Product.DriveConfiguration);
            }
            else if (propertyName.Equals("screenDiagonal", StringComparison.InvariantCultureIgnoreCase))
            {
                return nameof(Product.ScreenDiagonal);
            }
            else if (propertyName.Equals("screenResolution", StringComparison.InvariantCultureIgnoreCase))
            {
                return nameof(Product.ScreenResolution);
            }
            else if (propertyName.Equals("cost", StringComparison.InvariantCultureIgnoreCase))
            {
                return nameof(Product.Cost);
            }
            else if (propertyName.Equals("smount", StringComparison.InvariantCultureIgnoreCase))
            {
                return nameof(Product.Amount);
            }
            else if (propertyName.Equals("inStock", StringComparison.InvariantCultureIgnoreCase))
            {
                return nameof(Product.InStock);
            }

            return propertyName;
        }
    }
}
