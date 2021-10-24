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

namespace ComputerTechnicianBackend.API.Application.Queries.OrderQueries
{
    public class SearchOrderQuery : PagedSearchQuery<FoundOrderDTO, OrderSearchCondition>
    {
        public SearchOrderQuery(OrderSearchCondition searchCondition) : base(searchCondition)
        { }
    }

    public class SearchOrderQueryHandler : IRequestHandler<SearchOrderQuery, PagedResponse<FoundOrderDTO>>
    {
        private readonly IOrderService orderService;

        public SearchOrderQueryHandler(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public async Task<PagedResponse<FoundOrderDTO>> Handle(SearchOrderQuery request, CancellationToken cancellationToken)
        {
            var searchCondition = new OrderSearchCondition()
            {
                OrderStatus = GetFilterValues(request.SearchCondition.OrderStatus),
                Page = request.SearchCondition.Page,
                PageSize = request.SearchCondition.PageSize,
                SortDirection = request.SearchCondition.SortDirection,
                SortProperty = request.SearchCondition.SortProperty
            };

            var sortProperty = GetSortProperty(searchCondition.SortProperty);
            IReadOnlyCollection<Order> foundOrder = await orderService.FindAsync(searchCondition, sortProperty);
            FoundOrderDTO[] mappedOrder = foundOrder.Select(MapToFoundOrderDTO).ToArray();
            var totalCount = await orderService.CountAsync(searchCondition);

            return new PagedResponse<FoundOrderDTO>
            {
                Items = mappedOrder,
                TotalCount = totalCount
            };
        }

        private FoundOrderDTO MapToFoundOrderDTO(Order order)
        {
            return new FoundOrderDTO
            {
                Id = order.Id,
                OrderStatus = order.OrderStatus,
                OrderDate = order.OrderDate,
                OrderTime = order.OrderTime
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
                return nameof(Order.Id);
            }

            if (propertyName.Equals("orderStatus", StringComparison.InvariantCultureIgnoreCase))
            {
                return nameof(Order.OrderStatus);
            }

            return propertyName;
        }
    }
}
