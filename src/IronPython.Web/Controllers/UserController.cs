using IronPython.Infrastructure.Aspects;
using IronPython.User.Contracts;
using IronPython.User.Contracts.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IronPython.Api.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController(IMediator mediator)
        {
            Mediator=mediator;
        }

        public IMediator Mediator { get; }

        [HttpPost]
        [LogException()]
        public async Task<IActionResult> CreateUser(CreateUserDTO user)
        {
            var response = await Mediator.Send(new CreateUserQuery(user));

            return Ok(response);
        }
    }
}
