using System.Threading;
using System.Threading.Tasks;
using ComputerTechnicianBackend.API.Application.Commands.AuthCommands;
using ComputerTechnicianBackend.API.Application.Commands.ProductCommands;
using ComputerTechnicianBackend.API.Application.Commands.SupplierCommands;
using ComputerTechnicianBackend.API.Application.Queries.AuthQueries;
using ComputerTechnicianBackend.API.Application.Queries.MailQueries;
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
    [Route("api/v{version:apiVersion}/mail")]
    [ApiController]
    public class MailConroller : MediatingControllerBase
    {
        public MailConroller(IMediator mediator) : base(mediator)
        { }

        [HttpGet("genetate")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(OkResult))]
        [SwaggerOperation(Summary = "Generate pdf and send", OperationId = "Genetate")]
        public async Task<IActionResult> Genetate(CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(new GenerateMailPdfQuery(), cancellationToken: cancellationToken);
        }
    }
}
