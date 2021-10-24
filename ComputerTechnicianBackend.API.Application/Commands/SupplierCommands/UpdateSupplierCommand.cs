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
using ComputerTechnicianBackend.API.Contracts.Outgoing.Abstractions;

namespace ComputerTechnicianBackend.API.Application.Commands.SupplierCommands
{
    public class UpdateSupplierCommand : SupplierCommandBase<Response>
    {
        public UpdateSupplierCommand(long id, SupplierDTO update) : base(id, update) { }
    }

    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, Response>
    {
        private readonly ISupplierService supplierService;

        public UpdateSupplierCommandHandler(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
        }

        public async Task<Response> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await supplierService.GetAsync(request.Id, cancellationToken);

            if (supplier == null)
            {
                return Response.Error;
            }

            var supplierToUpdate = MapDTOToSupplier(request.Entity, supplier);

            var updatedSupplier = await supplierService.UpdateAsync(supplierToUpdate);

            if (updatedSupplier == null)
            {
                return Response.Error;
            }

            return Response.Successful;
        }

        public Supplier MapDTOToSupplier(SupplierDTO supplierDTO, Supplier supplier)
        {
            supplier.Address = supplierDTO.Address;
            supplier.City = supplierDTO.City;
            supplier.Country = supplierDTO.Country;
            supplier.Name = supplierDTO.Name;

            return supplier;
        }
    }
}
