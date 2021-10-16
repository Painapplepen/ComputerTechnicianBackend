using System.Threading;
using System.Threading.Tasks;
using ComputerTechnicianBackend.API.Application.Commands.ProductCommands;
using ComputerTechnicianBackend.API.Application.Queries.ProductQueries;
using ComputerTechnicianBackend.API.Contracts.Incoming.SearchConditions;
using ComputerTechnicianBackend.API.Contracts.IncomingOutgoing;
using ComputerTechnicianBackend.API.Contracts.Outgoing;
using ComputerTechnicianBackend.API.Contracts.Outgoing.Abstractions;
using LibraryService.API.Host.Controllers.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;


namespace ComputerTechnicianBackend.API.Host.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : MediatingControllerBase
    {
        public ProductController(IMediator mediator) : base(mediator)
        { }

        [HttpPost("search")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(PagedResponse<FoundProductDTO>))]
        [SwaggerOperation(Summary = "Search products", OperationId = "SearchProduct")]
        public async Task<IActionResult> SearchProducts([FromBody] ProductSearchCondition searchCondition, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(new SearchProductQuery(searchCondition), cancellationToken: cancellationToken);
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(long))]
        [SwaggerOperation(Summary = "Add a new product", OperationId = "AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDTO product, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(new AddProductCommand(product), cancellationToken: cancellationToken);
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(OkResult))]
        [SwaggerOperation(Summary = "Delete a product", OperationId = "DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(new DeleteProductCommand(id), cancellationToken: cancellationToken);
        }

        [HttpPut("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ProductDTO))]
        [SwaggerOperation(Summary = "Update a product", OperationId = "UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromRoute] long id, [FromBody] ProductDTO product, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(new UpdateProductCommand(id, product), cancellationToken: cancellationToken);
        }

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ProductDTO))]
        [SwaggerOperation(Summary = "Get the details of a product", OperationId = "GetProduct")]
        public async Task<IActionResult> GetProduct([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(new GetProductQuery(id), cancellationToken: cancellationToken);
        }
    }
}
