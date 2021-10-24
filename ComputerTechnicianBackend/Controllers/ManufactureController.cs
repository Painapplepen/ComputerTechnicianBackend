using System.Threading;
using System.Threading.Tasks;
using ComputerTechnicianBackend.API.Application.Commands.ManafactureCommands;
using ComputerTechnicianBackend.API.Application.Queries.ManafactureQueries;
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
    [Route("api/manufacture")]
    [ApiController]
    [Authorize]
    public class ManufactureController : MediatingControllerBase
    {
        public ManufactureController(IMediator mediator) : base(mediator)
        { }

        [HttpPost("search")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(PagedResponse<FoundManufactureDTO>))]
        [SwaggerOperation(Summary = "Search manufacture", OperationId = "SearchManufacture")]
        public async Task<IActionResult> SearchManufactures([FromBody] ManufactureSearchCondition searchCondition, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(new SearchManufactureQuery(searchCondition), cancellationToken: cancellationToken);
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(long))]
        [SwaggerOperation(Summary = "Add a new manufacture", OperationId = "AddManufacture")]
        public async Task<IActionResult> AddManufacture([FromBody] ManufactureDTO manufacture, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(new AddManufactureCommand(manufacture), cancellationToken: cancellationToken);
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(OkResult))]
        [SwaggerOperation(Summary = "Delete a manufacture", OperationId = "DeleteManufacture")]
        public async Task<IActionResult> DeleteManufacture([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(new DeleteManufactureCommand(id), cancellationToken: cancellationToken);
        }

        [HttpPut("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ManufactureDTO))]
        [SwaggerOperation(Summary = "Update a manufacture", OperationId = "UpdateManufacture")]
        public async Task<IActionResult> UpdateManufacture([FromRoute] long id, [FromBody] ManufactureDTO manufacture, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(new UpdateManufactureCommand(id, manufacture), cancellationToken: cancellationToken);
        }

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ManufactureDTO))]
        [SwaggerOperation(Summary = "Get the details of a manufacture", OperationId = "GetManufacture")]
        public async Task<IActionResult> GetManufacture([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(new GetManufactureQuery(id), cancellationToken: cancellationToken);
        }
    }
}
