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
    public class UpdateProductCommand : ProductCommandBase<ProductDTO>
    {
        public UpdateProductCommand(long id, ProductDTO update) : base(id, update) { }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDTO>
    {
        private readonly IProductService productService;

        public UpdateProductCommandHandler(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<ProductDTO> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await productService.GetAsync(request.Id, cancellationToken);

            var productToUpdate = MapDTOToProduct(request.Entity, product);

            var updatedProduct = await productService.UpdateAsync(productToUpdate);

            return MapToProductDTO(updatedProduct);
        }

        public Product MapDTOToProduct(ProductDTO productDTO, Product product)
        {
            product.Name = productDTO.Name;
            product.ReleaseDate = productDTO.ReleaseDate;
            product.Processor = productDTO.Processor;
            product.VidioCard = productDTO.VidioCard;
            product.MemoryCapacity = productDTO.MemoryCapacity;
            product.DriveConfiguration = productDTO.DriveConfiguration;
            product.ScreenDiagonal = productDTO.ScreenDiagonal;
            product.ScreenResolution = productDTO.ScreenResolution;
            product.Cost = productDTO.Cost;
            product.Amount = productDTO.Amount;
            product.InStock = productDTO.InStock;
            product.ProductTypeId = productDTO.ProductTypeId;

            return product;
        }

        public ProductDTO MapToProductDTO(Product product)
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
