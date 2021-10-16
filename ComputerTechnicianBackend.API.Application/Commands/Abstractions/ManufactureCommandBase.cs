using ComputerTechnicianBackend.API.Contracts.IncomingOutgoing;
using MediatR;

namespace ComputerTechnicianBackend.API.Application.Commands.Abstractions
{
    public class ManufactureCommandBase<TResponse> : IRequest<TResponse>
    {
        public ManufactureDTO Entity { get; set; }
        public long Id { get; set; }

        protected ManufactureCommandBase(long id, ManufactureDTO entity)
        {
            Id = id;
            Entity = entity;
        }

        protected ManufactureCommandBase(ManufactureDTO entity)
        {
            Entity = entity;
        }
    }
}
