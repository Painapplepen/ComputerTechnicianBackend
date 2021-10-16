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
    public class AddOrderCommand : OrderCommandBase<long>
    {
        public AddOrderCommand(OrderDTO order) : base(order) { }
    }

    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, long>
    {
        private readonly IOrderService orderService;

        public AddOrderCommandHandler(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public async Task<long> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var order = MapToOrder(request.Entity);
            var insertedOrder = await orderService.InsertAsync(order);
            return insertedOrder.Id;
        }

        private Order MapToOrder(OrderDTO order)
        {
            return new Order
            {
                OrderStatus = order.OrderStatus,
                OrderDate = order.OrderDate,
                OrderTime = order.OrderTime
            };
        }
    }
}
