using API.ActionFilters;
using Application.Commands.Orders;
using Application.Queries.Order;
using Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v{version:apiVersion}/Orders")]
    [ApiController]
    [Produces("text/json")]
    [ApiVersion("1")]
    public class OrtderController : ControllerBase
    {
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetOrder([FromRoute] long id, [FromServices] IMediator mediator)
        {
            var query = new GetOrderByIdQuery(id);
            var Order = await mediator.Send(query);
            return Ok(Order);
        }

        [HttpGet]
        [Route("{pageSize}/{pageNumber}/{merchant}")]
        public async Task<ActionResult> GetAllOrders([FromRoute] int? pageSize, [FromRoute] int? pageNumber, [FromRoute] int? userId, [FromServices] IMediator mediator)
        {
            var query = new GetAllOrdersQuery(pageSize, pageNumber, userId);
            var Orders = await mediator.Send(query);
            return Ok(Orders);
        }

        [UserTypeActionFilter(UserType.Admin)]
        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] AddOrderCommand command, [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [UserTypeActionFilter(UserType.Admin)]
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateOrder([FromBody] UpdateOrderCommand command, [FromServices] IMediator mediator)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [UserTypeActionFilter(UserType.Admin)]
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteOrder([FromRoute] DeleteOrderCommand command, [FromServices] IMediator mediator)
        {
            await mediator.Send(command);
            return NoContent();
        }
    }
}
