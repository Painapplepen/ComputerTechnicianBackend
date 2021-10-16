﻿using ComputerTechnicianBackend.API.Contracts.IncomingOutgoing;
using ComputerTechnicianBackend.Data.Domain.Models;
using ComputerTechnicianBackend.Data.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ComputerTechnicianBackend.API.Application.Queries.SupplierQueries
{
    public class GetSupplierQuery : IRequest<SupplierDTO>
    {
        public long Id { get; }

        public GetSupplierQuery(long id)
        {
            Id = id;
        }
    }

    public class GetSupplierQueryHandler : IRequestHandler<GetSupplierQuery, SupplierDTO>
    {
        private readonly ISupplierService supplierService;

        public GetSupplierQueryHandler(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
        }

        public async Task<SupplierDTO> Handle(GetSupplierQuery request, CancellationToken cancellationToken)
        {
            var author = await supplierService.GetAsync(request.Id, cancellationToken);

            if (author == null)
            {
                return null;
            }

            return MapToAuthorDTO(author);
        }

        private SupplierDTO MapToAuthorDTO(Supplier supplier)
        {
            return new SupplierDTO
            {
                Address = supplier.Address,
                City = supplier.City,
                Country = supplier.Country,
                Name = supplier.Name
            };
        }
    }
}
