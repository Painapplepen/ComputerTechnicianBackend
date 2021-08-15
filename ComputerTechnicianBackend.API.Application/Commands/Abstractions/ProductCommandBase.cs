using ComputerTechnicianBackend.API.Contracts.IncomingOutgoing;
using MediatR;

namespace ComputerTechnicianBackend.API.Application.Commands.Abstractions
{
    public class ProductCommandBase<TResponse> : IRequest<TResponse>
    {
        public ProductDTO Entity { get; set; }
        public long Id { get; set; }

        protected ProductCommandBase(long id, ProductDTO entity)
        {
            Id = id;
            Entity = entity;
        }

        protected ProductCommandBase(ProductDTO entity)
        {
            Entity = entity;
        }
    }
}
