using IronPython.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace IronPython.Authorization.Controllers
{
    [Route("authorization")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        public AuthorizationController(AuthorizationContext authorizationContext)
        {
            AuthorizationContext = authorizationContext;
        }

        public AuthorizationContext AuthorizationContext { get; }

        [HttpPost("withGoogle")]
        public IActionResult WithGoogle()
        {
            return Ok();
        }
    }
}
