using ComputerTechnicianBackend.API.Contracts.IncomingOutgoing;
using MediatR;

namespace ComputerTechnicianBackend.API.Application.Commands.Abstractions
{
    public class OrderCommandBase<TResponse> : IRequest<TResponse>
    {
        public OrderDTO Entity { get; set; }
        public long Id { get; set; }

        protected OrderCommandBase(long id, OrderDTO entity)
        {
            Id = id;
            Entity = entity;
        }

        protected OrderCommandBase(OrderDTO entity)
        {
            Entity = entity;
        }
    }
}
