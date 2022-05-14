using IronPython.TelegramBots.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IronPython.TelegramBots.Controllers
{
    [ApiController]
    [Route("telegram_bot")]
    public class TelegramBotController : ControllerBase
    {
        public TelegramBotController(TelegramBotsContext telegramBotsContext)
        {
            TelegramBotsContext = telegramBotsContext;
        }

        public TelegramBotsContext TelegramBotsContext { get; }

        [HttpGet("{id}"), Authorize]
        public IActionResult GetTelegramBotById([FromRoute] Guid id)
        {
            return Ok();
        }

        [HttpGet("GetTelegramBotsWithLimitAndOffset")]
        public IActionResult GetTelegramBotsWithLimitAndOffset([FromQuery] int limit, [FromQuery] int offset)
        {
            return Ok();
        }
    }
}
