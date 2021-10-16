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

namespace ComputerTechnicianBackend.API.Application.Commands.ManafactureCommands
{   
    public class UpdateManufactureCommand : ManufactureCommandBase<ManufactureDTO>
    {
        public UpdateManufactureCommand(long id, ManufactureDTO update) : base(id, update) { }
    }

    public class UpdateManufactureCommandHandler : IRequestHandler<UpdateManufactureCommand, ManufactureDTO>
    {
        private readonly IManufactureService manufactureService;

        public UpdateManufactureCommandHandler(IManufactureService manufactureService)
        {
            this.manufactureService = manufactureService;
        }

        public async Task<ManufactureDTO> Handle(UpdateManufactureCommand request, CancellationToken cancellationToken)
        {
            var manufacture = await manufactureService.GetAsync(request.Id, cancellationToken);

            var manufactureToUpdate = MapDTOToManafacture(request.Entity, manufacture);

            var updatedManufacture = await manufactureService.UpdateAsync(manufactureToUpdate);

            return MapToManafactureDTO(updatedManufacture);
        }

        public Manufacture MapDTOToManafacture(ManufactureDTO manufactureDTO, Manufacture manufacture)
        {
            manufacture.Address = manufactureDTO.Address;
            manufacture.City = manufactureDTO.City;
            manufacture.Country = manufactureDTO.Country;
            manufacture.Name = manufactureDTO.Name;
            return manufacture;
        }

        public ManufactureDTO MapToManafactureDTO(Manufacture manufacture)
        {
            return new ManufactureDTO
            {
                Address = manufacture.Address,
                City = manufacture.City,
                Country = manufacture.Country,
                Name = manufacture.Name
            };
        }
    }
}
