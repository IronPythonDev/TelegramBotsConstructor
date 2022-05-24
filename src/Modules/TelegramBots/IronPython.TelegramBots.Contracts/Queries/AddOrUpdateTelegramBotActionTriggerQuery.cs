using IronPython.TelegramBots.Contracts.DTOs;
using MediatR;

namespace IronPython.TelegramBots.Contracts.Queries
{
    public class AddOrUpdateTelegramBotActionTriggerQuery : IRequest
    {
        public AddOrUpdateTelegramBotActionTriggerQuery(TelegramBotActionTriggerDTO trigger, Guid actionId)
        {
            Trigger=trigger;
            ActionId=actionId;
        }

        public TelegramBotActionTriggerDTO Trigger { get; }
        public Guid ActionId { get; }
    }
}
