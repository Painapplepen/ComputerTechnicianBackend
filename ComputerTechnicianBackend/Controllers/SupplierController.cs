using System.Threading;
using System.Threading.Tasks;
using ComputerTechnicianBackend.API.Application.Commands.ProductCommands;
using ComputerTechnicianBackend.API.Application.Commands.SupplierCommands;
using ComputerTechnicianBackend.API.Application.Queries.ProductQueries;
using ComputerTechnicianBackend.API.Application.Queries.SupplierQueries;
using ComputerTechnicianBackend.API.Contracts.Incoming.SearchConditions;
using ComputerTechnicianBackend.API.Contracts.IncomingOutgoing;
using ComputerTechnicianBackend.API.Contracts.Outgoing;
using ComputerTechnicianBackend.API.Contracts.Outgoing.Abstractions;
using LibraryService.API.Host.Controllers.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ComputerTechnicianBackend.API.Host.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/supplier")]
    [ApiController]
    [Authorize]
    public class SupplierController : MediatingControllerBase
    {
        public SupplierController(IMediator mediator) : base(mediator)
        { }

        [HttpPost("search")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(PagedResponse<FoundSupplierDTO>))]
        [SwaggerOperation(Summary = "Search suppliers", OperationId = "SearchSupplier")]
        public async Task<IActionResult> SearchSuppliers([FromBody] SupplierSearchCondition searchCondition, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(new SearchSupplierQuery(searchCondition), cancellationToken: cancellationToken);
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(long))]
        [SwaggerOperation(Summary = "Add a new supplier", OperationId = "AddSupplier")]
        public async Task<IActionResult> AddSupplier([FromBody] SupplierDTO supplier, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(new AddSupplierCommand(supplier), cancellationToken: cancellationToken);
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(OkResult))]
        [SwaggerOperation(Summary = "Delete a supplier", OperationId = "DeleteSupplier")]
        public async Task<IActionResult> DeleteSupplier([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(new DeleteSupplierCommand(id), cancellationToken: cancellationToken);
        }

        [HttpPut("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(SupplierDTO))]
        [SwaggerOperation(Summary = "Update a supplier", OperationId = "UpdateSupplier")]
        public async Task<IActionResult> UpdateSupplier([FromRoute] long id, [FromBody] SupplierDTO supplier, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(new UpdateSupplierCommand(id, supplier), cancellationToken: cancellationToken);
        }

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(SupplierDTO))]
        [SwaggerOperation(Summary = "Get the details of a supplier", OperationId = "GetSupplier")]
        public async Task<IActionResult> GetSupplier([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(new GetSupplierQuery(id), cancellationToken: cancellationToken);
        }
    }
}
