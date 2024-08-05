using Application.Commands.Login;
using Application.Commands.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v{version:apiVersion}")]
    [ApiController]
    [Produces("text/json")]
    [ApiVersion("1")]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterUserCommand command, [FromServices] IMediator mediator)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdminAsync([FromBody] RegisterUserCommand command, [FromServices] IMediator mediator)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginCommand command, [FromServices] IMediator mediator)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
