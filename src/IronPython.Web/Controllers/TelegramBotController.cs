using IronPython.TelegramBots.Contracts.DTOs;
using IronPython.TelegramBots.Contracts.Queries;
using IronPython.User.Contracts.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBot(Guid id)
        {
            return Ok(await Mediator.Send(new GetTelegramBotByIdQuery(id)));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateBot(TelegramBotDTO telegramBot)
        {
            var user = await Mediator.Send(new GetUserByEmailQuery(User.Identity!.Name!));

            var newBot = await Mediator.Send(new CreateTelegramBotQuery(telegramBot, user.Id));

            return Ok(newBot);
        }

        [Authorize]
        [HttpGet("{telegramBotId}/action")]
        public async Task<IActionResult> GetBotActions(Guid telegramBotId)
        {
            return Ok(await Mediator.Send(new GetTelegramBotActionsByBotIdQuery(telegramBotId)));
        }

        [Authorize]
        [HttpPost("{telegramBotId}/action")]
        public async Task<IActionResult> CreateBotAction([FromRoute] Guid telegramBotId, [FromBody] TelegramBotActionDTO actionDTO)
        {
            await Mediator.Send(new AddOrUpdateTelegramBotActionQuery(actionDTO, telegramBotId));

            return Ok();
        }

        [Authorize]
        [HttpPost("{telegramBotId}/action/{actionId}/trigger")]
        public async Task<IActionResult> CreateBotActionTrigger([FromRoute] Guid telegramBotId, [FromRoute] Guid actionId, [FromBody] TelegramBotActionTriggerDTO triggerDTO)
        {
            await Mediator.Send(new AddOrUpdateTelegramBotActionTriggerQuery(triggerDTO, actionId));

            return Ok();
        }

        [Authorize]
        [HttpPost("{telegramBotId}/action/{actionId}/task")]
        public async Task<IActionResult> CreateBotActionTask([FromRoute] Guid telegramBotId, [FromRoute] Guid actionId, [FromBody] TelegramBotActionTaskDTO taskDTO)
        {
            await Mediator.Send(new AddOrUpdateTelegramBotActionTaskQuery(taskDTO, actionId));

            return Ok();
        }
    }
}
