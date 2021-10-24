using ComputerTechnicianBackend.Data.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ComputerTechnicianBackend.API.Application.Commands.UserCommands
{
    public class DeleteUserCommand : IRequest
    {
        public long Id { get; }

        public DeleteUserCommand(long id)
        {
            Id = id;
        }
    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserService userService;

        public DeleteUserCommandHandler(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await userService.DeleteAsync(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
