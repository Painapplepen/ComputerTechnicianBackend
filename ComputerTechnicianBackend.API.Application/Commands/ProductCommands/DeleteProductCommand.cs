using ComputerTechnicianBackend.Data.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ComputerTechnicianBackend.API.Application.Commands.ProductCommands
{
    public class DeleteProductCommand : IRequest
    {
        public long Id { get; }

        public DeleteProductCommand(long id)
        {
            Id = id;
        }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IOrderService orderService;

        public DeleteProductCommandHandler(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await orderService.DeleteAsync(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
