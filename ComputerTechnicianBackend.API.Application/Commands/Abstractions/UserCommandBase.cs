using ComputerTechnicianBackend.API.Contracts.IncomingOutgoing;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerTechnicianBackend.API.Application.Commands.Abstractions
{
    public class UserCommandBase<TResponse> : IRequest<TResponse>
    {
        public UserDTO Entity { get; set; }
        public long Id { get; set; }

        protected UserCommandBase(long id, UserDTO entity)
        {
            Id = id;
            Entity = entity;
        }

        protected UserCommandBase(UserDTO entity)
        {
            Entity = entity;
        }
    }
}
