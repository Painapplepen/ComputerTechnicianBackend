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
    public class DeleteManufactureCommand : IRequest
    {
        public long Id { get; }

        public DeleteManufactureCommand(long id)
        {
            Id = id;
        }
    }

    public class DeleteManafactureCommandHandler : IRequestHandler<DeleteManufactureCommand>
    {
        private readonly IManufactureService manufactureService;

        public DeleteManafactureCommandHandler(IManufactureService manufactureService)
        {
            this.manufactureService = manufactureService; 
        }

        public async Task<Unit> Handle(DeleteManufactureCommand request, CancellationToken cancellationToken){
            await manufactureService.DeleteAsync(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
