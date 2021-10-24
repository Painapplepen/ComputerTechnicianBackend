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

namespace ComputerTechnicianBackend.API.Application.Commands.ManafactureCommands
{   
    public class UpdateManufactureCommand : ManufactureCommandBase<Response>
    {
        public UpdateManufactureCommand(long id, ManufactureDTO update) : base(id, update) { }
    }

    public class UpdateManufactureCommandHandler : IRequestHandler<UpdateManufactureCommand, Response>
    {
        private readonly IManufactureService manufactureService;

        public UpdateManufactureCommandHandler(IManufactureService manufactureService)
        {
            this.manufactureService = manufactureService;
        }

        public async Task<Response> Handle(UpdateManufactureCommand request, CancellationToken cancellationToken)
        {
            var manufacture = await manufactureService.GetAsync(request.Id, cancellationToken);

            if (manufacture == null)
            {
                return Response.Error;
            }

            var manufactureToUpdate = MapDTOToManafacture(request.Entity, manufacture);

            var updatedManufacture = await manufactureService.UpdateAsync(manufactureToUpdate);

            if (updatedManufacture == null)
            {
                return Response.Error;
            }

            return Response.Successful;
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
