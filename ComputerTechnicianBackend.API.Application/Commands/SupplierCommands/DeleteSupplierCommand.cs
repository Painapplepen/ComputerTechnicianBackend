using ComputerTechnicianBackend.Data.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ComputerTechnicianBackend.API.Application.Commands.SupplierCommands
{
    public class DeleteSupplierCommand : IRequest
    {
        public long Id { get; }

        public DeleteSupplierCommand(long id)
        {
            Id = id;
        }
    }

    public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand>
    {
        private readonly ISupplierService supplierService;

        public DeleteSupplierCommandHandler(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
        }

        public async Task<Unit> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            await supplierService.DeleteAsync(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
