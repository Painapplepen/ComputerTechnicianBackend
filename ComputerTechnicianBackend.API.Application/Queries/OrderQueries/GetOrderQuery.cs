using ComputerTechnicianBackend.API.Contracts.IncomingOutgoing;
using ComputerTechnicianBackend.Data.Domain.Models;
using ComputerTechnicianBackend.Data.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace ComputerTechnicianBackend.API.Application.Queries.OrderQueries
{
    public class GetOrderQuery : IRequest<OrderDTO>
    {
        public long Id { get; }

        public GetOrderQuery(long id)
        {
            Id = id;
        }
    }

    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderDTO>
    {
        private readonly IOrderService orderService;

        public GetOrderQueryHandler(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public async Task<OrderDTO> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await orderService.GetAsync(request.Id, cancellationToken);

            if (order == null)
            {
                return null;
            }

            return MapToOrderDTO(order);
        }

        private OrderDTO MapToOrderDTO(Order order)
        {
            return new OrderDTO
            {
                OrderStatus = order.OrderStatus,
                OrderDate = order.OrderDate,
                OrderTime = order.OrderTime
            };
        }
    }
}
