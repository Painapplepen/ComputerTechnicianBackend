using ComputerTechnicianBackend.Data.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ComputerTechnicianBackend.API.Application.Commands.PersonalDataCommands
{
    public class DeletePersonalDataCommand : IRequest
    {
        public long Id { get; }

        public DeletePersonalDataCommand(long id)
        {
            Id = id;
        }
    }

    public class DeletePersonalDataCommandHandler : IRequestHandler<DeletePersonalDataCommand>
    {
        private readonly IPersonalDataService personalDataService;

        public DeletePersonalDataCommandHandler(IPersonalDataService personalDataService)
        {
            this.personalDataService = personalDataService;
        }

        public async Task<Unit> Handle(DeletePersonalDataCommand request, CancellationToken cancellationToken)
        {
            await personalDataService.DeleteAsync(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
