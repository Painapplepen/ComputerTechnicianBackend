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

namespace ComputerTechnicianBackend.API.Application.Queries.ManafactureQueries
{
    public class SearchManufactureQuery : PagedSearchQuery<FoundManufactureDTO, ManufactureSearchCondition>
    {
        public SearchManufactureQuery(ManufactureSearchCondition searchCondition) : base(searchCondition)
        { }
    }

    public class SearchManufactureQueryHandler : IRequestHandler<SearchManufactureQuery, PagedResponse<FoundManufactureDTO>>
    {
        private readonly IManufactureService manufactureService;

        public SearchManufactureQueryHandler(IManufactureService manufactureService)
        {
            this.manufactureService = manufactureService;
        }

        public async Task<PagedResponse<FoundManufactureDTO>> Handle(SearchManufactureQuery request, CancellationToken cancellationToken)
        {
            var searchCondition = new ManufactureSearchCondition()
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
            IReadOnlyCollection<Manufacture> foundManufacture = await manufactureService.FindAsync(searchCondition, sortProperty);
            FoundManufactureDTO[] mappedManufacture = foundManufacture.Select(MapToFoundManufactureDTO).ToArray();
            var totalCount = await manufactureService.CountAsync(searchCondition);

            return new PagedResponse<FoundManufactureDTO>
            {
                Items = mappedManufacture,
                TotalCount = totalCount
            };
        }

        private FoundManufactureDTO MapToFoundManufactureDTO(Manufacture manufacture)
        {
            return new FoundManufactureDTO
            {
                Id = manufacture.Id,
                Address = manufacture.Address,
                City = manufacture.City,
                Country = manufacture.Country,
                Name = manufacture.Name
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
                return nameof(Manufacture.Id);
            }
            else if (propertyName.Equals("address", StringComparison.InvariantCultureIgnoreCase))
            {
                return nameof(Manufacture.Address);
            }
            else if (propertyName.Equals("city", StringComparison.InvariantCultureIgnoreCase))
            {
                return nameof(Manufacture.City);
            }
            else if (propertyName.Equals("country", StringComparison.InvariantCultureIgnoreCase))
            {
                return nameof(Manufacture.Country);
            }
            else if (propertyName.Equals("name", StringComparison.InvariantCultureIgnoreCase))
            {
                return nameof(Manufacture.Name);
            }

            return propertyName;
        }
    }
}
