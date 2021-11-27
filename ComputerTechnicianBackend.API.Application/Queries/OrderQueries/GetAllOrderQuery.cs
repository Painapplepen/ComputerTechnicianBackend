using ComputerTechnicianBackend.API.Contracts.Outgoing;
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
    public class GetAllOrderQuery : IRequest<IReadOnlyCollection<FoundOrderDTO>>
    {
        public GetAllOrderQuery() { }
    }

    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQuery, IReadOnlyCollection<FoundOrderDTO>>
    {
        private readonly IOrderService orderService;

        public GetAllOrderQueryHandler(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public async Task<IReadOnlyCollection<FoundOrderDTO>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            var orders = await orderService.GetAllAsync(cancellationToken);

            return orders.Select(MapToFoundOrderDTO).ToArray();
        }

        private FoundOrderDTO MapToFoundOrderDTO(Order order)
        {
            return new FoundOrderDTO
            {
                Id = order.Id,
                OrderTime = order.OrderTime,
                OrderStatus = order.OrderStatus,
                OrderDate = order.OrderDate
            };
        }
    }
}
