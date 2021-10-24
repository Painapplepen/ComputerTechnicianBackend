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

namespace ComputerTechnicianBackend.API.Application.Commands.UserCommands
{
    public class UpdateUserCommand : UserCommandBase<Response>
    {
        public UpdateUserCommand(long id, UserDTO update) : base(id, update) { }
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response>
    {
        private readonly IUserService userService;

        public UpdateUserCommandHandler(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<Response> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userService.GetAsync(request.Id, cancellationToken);

            if (user == null)
            {
                return Response.Error;
            }

            var userToUpdate = MapDTOToGenre(request.Entity, user);

            var updatedUser = await userService.UpdateAsync(userToUpdate);

            if (updatedUser == null)
            {
                return Response.Error;
            }

            return Response.Successful;
        }

        public User MapDTOToGenre(UserDTO userDTO, User user)
        {
            user.UserName = userDTO.UserName;
            user.Password = userDTO.Password;
            user.Email = userDTO.Email;
            user.RoleId = userDTO.RoleId.Value;

            return user;
        }
    }
}
