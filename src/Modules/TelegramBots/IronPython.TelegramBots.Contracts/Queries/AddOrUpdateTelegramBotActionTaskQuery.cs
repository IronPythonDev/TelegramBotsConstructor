using IronPython.TelegramBots.Contracts.DTOs;
using MediatR;

namespace IronPython.TelegramBots.Contracts.Queries
{
    public class AddOrUpdateTelegramBotActionTaskQuery : IRequest
    {
        public AddOrUpdateTelegramBotActionTaskQuery(TelegramBotActionTaskDTO task, Guid actionId)
        {
            Task=task;
            ActionId=actionId;
        }

        public TelegramBotActionTaskDTO Task { get; }
        public Guid ActionId { get; }
    }
}
