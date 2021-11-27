using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ComputerTechnicianBackend.API.Application.Commands.UserCommands;
using ComputerTechnicianBackend.API.Application.Queries.UserQueries;
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
    [Route("api/v{version:apiVersion}/user")]
    [ApiController]
    [Authorize]
    public class UserController : MediatingControllerBase
    {
        public UserController(IMediator mediator) : base(mediator)
        { }

        [HttpPost("search")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(PagedResponse<FoundUserDTO>))]
        [SwaggerOperation(Summary = "Search user", OperationId = "SearchUser")]
        public async Task<IActionResult> SearchUser([FromBody] UserSearchCondition searchCondition, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(new SearchUserQuery(searchCondition), cancellationToken: cancellationToken);
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(long))]
        [SwaggerOperation(Summary = "Add a new user", OperationId = "AddUser")]
        public async Task<IActionResult> AddUser([FromBody] UserDTO user, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(new AddUserCommand(user), cancellationToken: cancellationToken);
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(OkResult))]
        [SwaggerOperation(Summary = "Delete a user", OperationId = "DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(new DeleteUserCommand(id), cancellationToken: cancellationToken);
        }

        [HttpPut("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(UserDTO))]
        [SwaggerOperation(Summary = "Update a user", OperationId = "UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromRoute] long id, [FromBody] UserDTO user, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(new UpdateUserCommand(id, user), cancellationToken: cancellationToken);
        }

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(UserDTO))]
        [SwaggerOperation(Summary = "Get the details of a user", OperationId = "GetUser")]
        public async Task<IActionResult> GetUser([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(new GetUserQuery(id), cancellationToken: cancellationToken);
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<FoundUserDTO>))]
        [SwaggerOperation(Summary = "Get all users", OperationId = "GetAllUsers")]
        public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(new GetAllUserQuery(), cancellationToken: cancellationToken);
        }
    }
}
