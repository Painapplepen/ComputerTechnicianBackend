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

namespace ComputerTechnicianBackend.API.Application.Commands.SupplierCommands
{
    public class AddSupplierCommand : SupplierCommandBase<long>
    {
        public AddSupplierCommand(SupplierDTO supplier) : base(supplier) { }
    }

    public class AddSupplierCommandHandler : IRequestHandler<AddSupplierCommand, long>
    {
        private readonly ISupplierService supplierService;

        public AddSupplierCommandHandler(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
        }

        public async Task<long> Handle(AddSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = MapToSupplier(request.Entity);
            var insertedSupplier = await supplierService.InsertAsync(supplier);
            return insertedSupplier.Id;
        }

        private Supplier MapToSupplier(SupplierDTO supplier)
        {
            return new Supplier
            {
                Address = supplier.Address,
                City = supplier.City,
                Country = supplier.Country,
                Name = supplier.Name
            };
        }
    }
}
