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
    public class AddManufactureCommand : ManufactureCommandBase<long>
    {
        public AddManufactureCommand(ManufactureDTO manafacture) : base(manafacture) { }
    }

    public class AddManafctureCommandHandler : IRequestHandler<AddManufactureCommand, long>
    {
        private readonly IManafactureService manafactureService;

        public AddManafctureCommandHandler(IManafactureService manafactureService)
        {
            this.manafactureService = manafactureService;
        }

        public async Task<long> Handle(AddManufactureCommand request, CancellationToken cancellationToken)
        {
            var manufacture = MapToManufcture(request.Entity);
            var insertManufacture = await manafactureService.InsertAsync(manufacture);
            return insertManufacture.Id;
        }

        private Manufacture MapToManufcture(ManufactureDTO manufacture)
        {
            return new Manufacture
            {
                Address = manufacture.Address,
                City = manufacture.City,
                Country = manufacture.Country,
                Name = manufacture.Name
            };
        }
    }
}
