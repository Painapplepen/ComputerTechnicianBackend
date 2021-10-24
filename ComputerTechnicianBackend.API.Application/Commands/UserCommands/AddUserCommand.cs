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

namespace ComputerTechnicianBackend.API.Application.Commands.UserCommands
{
    public class AddUserCommand : UserCommandBase<long>
    {
        public AddUserCommand(UserDTO user) : base(user) { }
    }

    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, long>
    {
        private readonly IUserService userService;

        public AddUserCommandHandler(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<long> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = MapToUser(request.Entity);
            var insertedUser = await userService.InsertAsync(user);
            return insertedUser.Id;
        }

        private User MapToUser(UserDTO user)
        {
            return new User
            {
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                RoleId = user.RoleId.Value,
            };
        }
    }
}
