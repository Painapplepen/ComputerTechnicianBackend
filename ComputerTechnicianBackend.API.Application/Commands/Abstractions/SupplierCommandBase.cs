using ComputerTechnicianBackend.API.Contracts.IncomingOutgoing;
using MediatR;

namespace ComputerTechnicianBackend.API.Application.Commands.Abstractions
{
    public class SupplierCommandBase<TResponse> : IRequest<TResponse>
    {
        public SupplierDTO Entity { get; set; }
        public long Id { get; set; }

        protected SupplierCommandBase(long id, SupplierDTO entity)
        {
            Id = id;
            Entity = entity;
        }

        protected SupplierCommandBase(SupplierDTO entity)
        {
            Entity = entity;
        }
    }
}
