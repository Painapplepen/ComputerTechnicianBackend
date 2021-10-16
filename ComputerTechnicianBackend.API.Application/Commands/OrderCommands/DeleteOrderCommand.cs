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
    public class DeleteOrderCommand : IRequest
    {
        public long Id { get; }

        public DeleteOrderCommand(long id)
        {
            Id = id;
        }
    }

    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IOrderService orderService;

        public DeleteOrderCommandHandler(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            await orderService.DeleteAsync(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
