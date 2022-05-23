using IronPython.TelegramBots.Contracts.DTOs;
using IronPython.TelegramBots.Contracts.Queries;
using IronPython.User.Contracts.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IronPython.Api.Controllers
{
    [Route("telegramBot")]
    [ApiController]
    public class TelegramBotController : ControllerBase
    {
        public TelegramBotController(IMediator mediator)
        {
            Mediator=mediator;
        }

        public IMediator Mediator { get; }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateBot(TelegramBotDTO telegramBot)
        {
            var user = await Mediator.Send(new GetUserByEmailQuery(User.Identity!.Name!));

            var newBot = await Mediator.Send(new CreateTelegramBotQuery(telegramBot, user.Id));

            return Ok(newBot);
        } 
    }
}
