using System.Threading;
using System.Threading.Tasks;
using ComputerTechnicianBackend.API.Application.Commands.PersonalDataCommands;
using ComputerTechnicianBackend.API.Application.Queries.PersonalDataQueries;
using ComputerTechnicianBackend.API.Contracts.IncomingOutgoing;
using LibraryService.API.Host.Controllers.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ComputerTechnicianBackend.API.Host.Controllers
{
    [Route("api/profile")]
    [ApiController]
    [Authorize]
    public class PersonalDataController : MediatingControllerBase
    {
        public PersonalDataController(IMediator mediator) : base(mediator)
        { }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(long))]
        [SwaggerOperation(Summary = "Add a new profile", OperationId = "AddProfile")]
        public async Task<IActionResult> AddProfileFund([FromBody] PersonalDataDTO personalData, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(new AddPersonalDataCommand(personalData), cancellationToken: cancellationToken);
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(OkResult))]
        [SwaggerOperation(Summary = "Delete a profile", OperationId = "DeleteProfile")]
        public async Task<IActionResult> DeleteProfile([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(new DeletePersonalDataCommand(id), cancellationToken: cancellationToken);
        }

        [HttpPut("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(PersonalDataDTO))]
        [SwaggerOperation(Summary = "Update a profile", OperationId = "UpdateProfile")]
        public async Task<IActionResult> UpdateProfile([FromRoute] long id, [FromBody] PersonalDataDTO personalData, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(new UpdatePersonalDataCommand(id, personalData), cancellationToken: cancellationToken);
        }

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(PersonalDataDTO))]
        [SwaggerOperation(Summary = "Get the details of a profile", OperationId = "GetProfile")]
        public async Task<IActionResult> GetProfile([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(new GetPersonalDataQuery(id), cancellationToken: cancellationToken);
        }
    }
}
