using ComputerTechnicianBackend.API.Contracts.IncomingOutgoing;
using MediatR;

namespace ComputerTechnicianBackend.API.Application.Commands.Abstractions
{
    public class LoginCommandBase<TResponse> : IRequest<TResponse>
    {
        public LoginDTO Entity { get; set; }
        public long Id { get; set; }

        protected LoginCommandBase(long id, LoginDTO entity)
        {
            Id = id;
            Entity = entity;
        }

        protected LoginCommandBase(LoginDTO entity)
        {
            Entity = entity;
        }
    }
}
