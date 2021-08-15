using ComputerTechnicianBackend.API.Contracts.IncomingOutgoing;
using MediatR;

namespace ComputerTechnicianBackend.API.Application.Commands.Abstractions
{
    public class ManafactureCommandBase<TResponse> : IRequest<TResponse>
    {
        public ManafactureDTO Entity { get; set; }
        public long Id { get; set; }

        protected ManafactureCommandBase(long id, ManafactureDTO entity)
        {
            Id = id;
            Entity = entity;
        }

        protected ManafactureCommandBase(ManafactureDTO entity)
        {
            Entity = entity;
        }
    }
}
