using API.ActionFilters;
using Application.Commands.Products;
using Application.Queries;
using Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v{version:apiVersion}/products")]
    [ApiController]
    [Produces("text/json")]
    [ApiVersion("1")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetProduct([FromRoute] long id, [FromServices] IMediator mediator)
        {
            var query = new GetProductByIdQuery(id);
            var product = await mediator.Send(query);
            return Ok(product);
        }

        [HttpGet]
        [Route("{pageSize}/{pageNumber}/{merchant}")]
        public async Task<ActionResult> GetAllProducts([FromRoute] int? pageSize, [FromRoute] int? pageNumber, [FromRoute] string? merchant, [FromServices] IMediator mediator)
        {
            var query = new GetAllProductsQuery(pageSize, pageNumber, merchant);
            var products = await mediator.Send(query);
            return Ok(products);
        }

        [UserTypeActionFilter(UserType.Admin)]
        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] AddProductCommand command, [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [UserTypeActionFilter(UserType.Admin)]
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateProduct([FromBody] UpdateProductCommand command, [FromServices] IMediator mediator)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [UserTypeActionFilter(UserType.Admin)]
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteProduct([FromRoute] DeleteProductCommand command, [FromServices] IMediator mediator)
        {
            await mediator.Send(command);
            return NoContent();
        }
    }
}