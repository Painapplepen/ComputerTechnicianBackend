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

namespace ComputerTechnicianBackend.API.Application.Commands.ProductCommands
{
    public class AddProductCommand : ProductCommandBase<long>
    {
        public AddProductCommand(ProductDTO product) : base(product) { }
    }

    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, long>
    {
        private readonly IProductService productService;

        public AddProductCommandHandler(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<long> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = MapToProduct(request.Entity);
            var insertedProduct = await productService.InsertAsync(product);
            return insertedProduct.Id;
        }

        private Product MapToProduct(ProductDTO product)
        {
            return new Product
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
