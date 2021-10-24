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

namespace ComputerTechnicianBackend.API.Application.Queries.SupplierQueries
{
    public class SearchSupplierQuery : PagedSearchQuery<FoundSupplierDTO, SupplierSearchCondition>
    {
        public SearchSupplierQuery(SupplierSearchCondition searchCondition) : base(searchCondition)
        { }
    }

    public class SearchSupplierQueryHandler : IRequestHandler<SearchSupplierQuery, PagedResponse<FoundSupplierDTO>>
    {
        private readonly ISupplierService supplierService;

        public SearchSupplierQueryHandler(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
        }

        public async Task<PagedResponse<FoundSupplierDTO>> Handle(SearchSupplierQuery request, CancellationToken cancellationToken)
        {
            var searchCondition = new SupplierSearchCondition()
            {
                Address = GetFilterValues(request.SearchCondition.Address),
                City = GetFilterValues(request.SearchCondition.City),
                Country = GetFilterValues(request.SearchCondition.Country),
                Name = GetFilterValues(request.SearchCondition.Name),
                Page = request.SearchCondition.Page,
                PageSize = request.SearchCondition.PageSize,
                SortDirection = request.SearchCondition.SortDirection,
                SortProperty = request.SearchCondition.SortProperty
            };

            var sortProperty = GetSortProperty(searchCondition.SortProperty);
            IReadOnlyCollection<Supplier> foundSupplier = await supplierService.FindAsync(searchCondition, sortProperty);
            FoundSupplierDTO[] mappedSupplier = foundSupplier.Select(MapToFoundSupplierDTO).ToArray();
            var totalCount = await supplierService.CountAsync(searchCondition);

            return new PagedResponse<FoundSupplierDTO>
            {
                Items = mappedSupplier,
                TotalCount = totalCount
            };
        }

        private FoundSupplierDTO MapToFoundSupplierDTO(Supplier supplier)
        {
            return new FoundSupplierDTO
            {
                Id = supplier.Id,
                Address = supplier.Address,
                City = supplier.City,
                Country = supplier.Country,
                Name = supplier.Name
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
                return nameof(Supplier.Id);
            }
            else if (propertyName.Equals("address", StringComparison.InvariantCultureIgnoreCase))
            {
                return nameof(Supplier.Address);
            }
            else if (propertyName.Equals("city", StringComparison.InvariantCultureIgnoreCase))
            {
                return nameof(Supplier.City);
            }
            else if (propertyName.Equals("country", StringComparison.InvariantCultureIgnoreCase))
            {
                return nameof(Supplier.Country);
            }
            else if (propertyName.Equals("name", StringComparison.InvariantCultureIgnoreCase))
            {
                return nameof(Supplier.Name);
            }

            return propertyName;
        }
    }
}
