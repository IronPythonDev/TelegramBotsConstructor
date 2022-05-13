using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IronPython.TelegramBots.Controllers
{
    [ApiController]
    [Route("telegram_bot")]
    public class TelegramBotController : ControllerBase
    {
        [HttpGet("{id}"), Authorize]
        public IActionResult GetTelegramBotById([FromRoute] Guid id)
        {
            return Ok();
        }

        [HttpGet, Authorize]
        public IActionResult GetTelegramBotsWithLimitAndOffset([FromQuery] int limit, [FromQuery] int offset)
        {
            return Ok();
        }
    }
}
