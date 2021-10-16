using ComputerTechnicianBackend.API.Contracts.IncomingOutgoing;
using ComputerTechnicianBackend.Data.Domain.Models;
using ComputerTechnicianBackend.Data.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ComputerTechnicianBackend.API.Application.Queries.ManafactureQueries
{
    public class GetManufactureQuery : IRequest<ManufactureDTO>
    {
        public long Id { get; }

        public GetManufactureQuery(long id)
        {
            Id = id;
        }
    }

    public class GetManufactureQueryHandler : IRequestHandler<GetManufactureQuery, ManufactureDTO>
    {
        private readonly IManufactureService manufactureService;

        public GetManufactureQueryHandler(IManufactureService manufactureService)
        {
            this.manufactureService = manufactureService;
        }

        public async Task<ManufactureDTO> Handle(GetManufactureQuery request, CancellationToken cancellationToken)
        {
            var manufacture = await manufactureService.GetAsync(request.Id, cancellationToken);

            if (manufacture == null)
            {
                return null;
            }

            return MapToManufactureDTO(manufacture);
        }

        private ManufactureDTO MapToManufactureDTO(Manufacture manufacture)
        {
            return new ManufactureDTO
            {
                Address = manufacture.Address,
                City = manufacture.City,
                Country = manufacture.Country,
                Name = manufacture.Name
            }; ;
        }
    }
}
