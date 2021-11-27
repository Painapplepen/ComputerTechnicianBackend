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

namespace ComputerTechnicianBackend.API.Application.Queries.ManafactureQueries
{
    public class GetAllManufactureQuery : IRequest<IReadOnlyCollection<FoundManufactureDTO>>
    {
        public GetAllManufactureQuery() { }
    }

    public class GetAllManufactureQueryHandler : IRequestHandler<GetAllManufactureQuery, IReadOnlyCollection<FoundManufactureDTO>>
    {
        private readonly IManufactureService manufactureService;

        public GetAllManufactureQueryHandler(IManufactureService manufactureService)
        {
            this.manufactureService = manufactureService;
        }

        public async Task<IReadOnlyCollection<FoundManufactureDTO>> Handle(GetAllManufactureQuery request, CancellationToken cancellationToken)
        {
            var manufactures = await manufactureService.GetAllAsync(cancellationToken);

            return manufactures.Select(MapToFoundManufactureDTO).ToArray();
        }

        private FoundManufactureDTO MapToFoundManufactureDTO(Manufacture manufacture)
        {
            return new FoundManufactureDTO
            {
                Id = manufacture.Id,
                Name = manufacture.Name,
                City = manufacture.City,
                Country = manufacture.Country,
                Address = manufacture.Address
            };
        }
    }
}
