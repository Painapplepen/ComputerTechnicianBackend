using ComputerTechnicianBackend.API.Application.Commands.Abstractions;
using ComputerTechnicianBackend.API.Contracts.IncomingOutgoing;
using ComputerTechnicianBackend.Data.Domain.Models;
using ComputerTechnicianBackend.Data.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ComputerTechnicianBackend.API.Application.Commands.OrderCommands
{
    public class UpdateOrderCommand : OrderCommandBase<OrderDTO>
    {
        public UpdateOrderCommand(long id, OrderDTO update) : base(id, update) { }
    }

    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, OrderDTO>
    {
        private readonly IOrderService orderService;

        public UpdateOrderCommandHandler(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public async Task<OrderDTO> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await orderService.GetAsync(request.Id, cancellationToken);

            var orderToUpdate = MapDTOToOrder(request.Entity, order);

            var updatedOrder = await orderService.UpdateAsync(orderToUpdate);

            return MapToOrderDTO(updatedOrder);
        }

        public Order MapDTOToOrder(OrderDTO orderDTO, Order order)
        {
            order.OrderStatus = orderDTO.OrderStatus;
            order.OrderDate = orderDTO.OrderDate;
            order.OrderTime = orderDTO.OrderTime;

            return order;
        }

        public OrderDTO MapToOrderDTO(Order order)
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
