using IronPython.Infrastructure.Aspects;
using IronPython.User.Contracts.DTOs;
using IronPython.User.Contracts.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [LogException]
        [Authorize]
        public async Task<IActionResult> GetUser()
        {
            var email = User.Identity!.Name;

            return Ok(email);
        }
    }
}
