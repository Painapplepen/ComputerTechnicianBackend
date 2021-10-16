using ComputerTechnicianBackend.API.Contracts.IncomingOutgoing;
using ComputerTechnicianBackend.Data.Domain.Models;
using ComputerTechnicianBackend.Data.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ComputerTechnicianBackend.API.Application.Queries.ProductQueries
{
    public class GetProductQuery : IRequest<ProductDTO>
    {
        public long Id { get; }

        public GetProductQuery(long id)
        {
            Id = id;
        }
    }

    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDTO>
    {
        private readonly IProductService productService;

        public GetProductQueryHandler(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<ProductDTO> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await productService.GetAsync(request.Id, cancellationToken);

            if (product == null)
            {
                return null;
            }

            return MapToProductDTO(product);
        }

        private ProductDTO MapToProductDTO(Product product)
        {
            return new ProductDTO
            {
                Name = product.Name,
                ReleaseDate = product.ReleaseDate,
                Processor = product.Processor,
                VidioCard = product.VidioCard,
                MemoryCapacity = product.MemoryCapacity,
                DriveConfiguration = product.DriveConfiguration,
                ScreenDiagonal = product.ScreenDiagonal,
                ScreenResolution = product.ScreenResolution,
                Cost = product.Cost,
                Amount = product.Amount,
                InStock = product.InStock,
                ProductTypeId = product.ProductTypeId
            };
        }
    }
}
