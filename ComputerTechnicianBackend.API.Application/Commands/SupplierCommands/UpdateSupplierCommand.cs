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
    public class UpdateSupplierCommand : SupplierCommandBase<SupplierDTO>
    {
        public UpdateSupplierCommand(long id, SupplierDTO update) : base(id, update) { }
    }

    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, SupplierDTO>
    {
        private readonly ISupplierService supplierService;

        public UpdateSupplierCommandHandler(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
        }

        public async Task<SupplierDTO> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await supplierService.GetAsync(request.Id, cancellationToken);

            var supplierToUpdate = MapDTOToSupplier(request.Entity, supplier);

            var updatedSupplier = await supplierService.UpdateAsync(supplierToUpdate);

            return MapToSupplierDTO(updatedSupplier);
        }

        public Supplier MapDTOToSupplier(SupplierDTO supplierDTO, Supplier supplier)
        {
            supplier.Address = supplierDTO.Address;
            supplier.City = supplierDTO.City;
            supplier.Country = supplierDTO.Country;
            supplier.Name = supplierDTO.Name;

            return supplier;
        }

        public SupplierDTO MapToSupplierDTO(Supplier supplier)
        {
            return new SupplierDTO()
            {
                Address = supplier.Address,
                City = supplier.City,
                Country = supplier.Country,
                Name = supplier.Name
            };
        }
    }
}
