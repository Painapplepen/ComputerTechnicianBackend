using System.Threading;
using System.Threading.Tasks;
using ComputerTechnicianBackend.API.Application.Commands.AuthCommands;
using ComputerTechnicianBackend.API.Application.Commands.ProductCommands;
using ComputerTechnicianBackend.API.Application.Commands.SupplierCommands;
using ComputerTechnicianBackend.API.Application.Queries.AuthQueries;
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
    [Route("api/auth")]
    [ApiController]
    public class AuthController : MediatingControllerBase
    {
        public AuthController(IMediator mediator) : base(mediator)
        { }

        [HttpPost]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(string))]
        [SwaggerOperation(Summary = "Login", OperationId = "Login")]
        public async Task<IActionResult> Login([FromBody] UserDTO user, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(new LoginUserQuery(user), cancellationToken: cancellationToken);
        }

        [HttpPost]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(bool))]
        [SwaggerOperation(Summary = "Register", OperationId = "Register")]
        public async Task<IActionResult> Register([FromBody] UserDTO user, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(new RegisterUserCommand(user), cancellationToken: cancellationToken);
        }
    }
}
