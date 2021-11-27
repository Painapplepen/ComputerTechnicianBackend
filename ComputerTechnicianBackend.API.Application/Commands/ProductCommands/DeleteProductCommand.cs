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
        private readonly IProductService productService;

        public DeleteProductCommandHandler(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await productService.DeleteAsync(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
