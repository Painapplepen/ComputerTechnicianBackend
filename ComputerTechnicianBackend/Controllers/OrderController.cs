using System.Threading;
using System.Threading.Tasks;
using ComputerTechnicianBackend.API.Application.Commands.OrderCommands;
using ComputerTechnicianBackend.API.Application.Queries.OrderQueries;
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
    [Route("api/v{version:apiVersion}/order")]
    [ApiController]
    [Authorize]
    public class OrderController : MediatingControllerBase
    {
        public OrderController(IMediator mediator) : base(mediator)
        { }

        [HttpPost("search")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(PagedResponse<FoundOrderDTO>))]
        [SwaggerOperation(Summary = "Search orders", OperationId = "SearchOrder")]
        public async Task<IActionResult> SearchOrders([FromBody] OrderSearchCondition searchCondition, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(new SearchOrderQuery(searchCondition), cancellationToken: cancellationToken);
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(long))]
        [SwaggerOperation(Summary = "Add a new order", OperationId = "AddOrder")]
        public async Task<IActionResult> AddOrder([FromBody] OrderDTO order, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(new AddOrderCommand(order), cancellationToken: cancellationToken);
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(OkResult))]
        [SwaggerOperation(Summary = "Delete a order", OperationId = "DeleteOrder")]
        public async Task<IActionResult> DeleteOrder([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(new DeleteOrderCommand(id), cancellationToken: cancellationToken);
        }

        [HttpPut("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(OrderDTO))]
        [SwaggerOperation(Summary = "Update a order", OperationId = "UpdateOrder")]
        public async Task<IActionResult> UpdateOrder([FromRoute] long id, [FromBody] OrderDTO order, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(new UpdateOrderCommand(id, order), cancellationToken: cancellationToken);
        }

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(OrderDTO))]
        [SwaggerOperation(Summary = "Get the details of a order", OperationId = "GetOrder")]
        public async Task<IActionResult> GetOrder([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(new GetOrderQuery(id), cancellationToken: cancellationToken);
        }
    }
}
