using ComputerTechnicianBackend.API.Contracts.Outgoing;
using ComputerTechnicianBackend.Data.Domain.Models;
using ComputerTechnicianBackend.Data.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ComputerTechnicianBackend.API.Application.Queries.SupplierQueries
{
    public class GetAllSupplierQuery : IRequest<IReadOnlyCollection<FoundSupplierDTO>>
    {
        public GetAllSupplierQuery() { }
    }

    public class GetAllSupplierQueryHandler : IRequestHandler<GetAllSupplierQuery, IReadOnlyCollection<FoundSupplierDTO>>
    {
        private readonly ISupplierService supplierService;

        public GetAllSupplierQueryHandler(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
        }

        public async Task<IReadOnlyCollection<FoundSupplierDTO>> Handle(GetAllSupplierQuery request, CancellationToken cancellationToken)
        {
            var suppliers = await supplierService.GetAllAsync(cancellationToken);

            return suppliers.Select(MapToFoundSupplierDTO).ToArray();
        }

        private FoundSupplierDTO MapToFoundSupplierDTO(Supplier supplier)
        {
            return new FoundSupplierDTO
            {
                Id = supplier.Id,
                Name = supplier.Name,
                City = supplier.City,
                Country = supplier.Country,
                Address = supplier.Address
            };
        }
    }
}
