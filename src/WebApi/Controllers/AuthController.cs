using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Analytics.Dashboard.Application.Auth.Commands;

namespace Project.Analytics.Dashboard.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("google")]
        public async Task<IActionResult> LoginGoogle(
            [FromBody] LoginGoogleCommand command,
            CancellationToken cancellationToken)
        {
            string token = await _mediator.Send(
                command,
                cancellationToken);

            return Ok(new
            {
                accessToken = token
            });
        }
    }
}
