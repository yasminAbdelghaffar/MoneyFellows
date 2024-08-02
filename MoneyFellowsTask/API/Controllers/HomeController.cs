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
            var response = mediator.Send(command);
            return Ok(response);
        }
    }
}
