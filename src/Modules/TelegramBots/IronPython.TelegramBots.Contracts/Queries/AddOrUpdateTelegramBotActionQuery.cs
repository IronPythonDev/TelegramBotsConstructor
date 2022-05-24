using IronPython.TelegramBots.Contracts.DTOs;
using MediatR;

namespace IronPython.TelegramBots.Contracts.Queries
{
    public class AddOrUpdateTelegramBotActionQuery : IRequest
    {
        public AddOrUpdateTelegramBotActionQuery(TelegramBotActionDTO telegramBotActionDTO, Guid telegramBotId)
        {
            TelegramBotActionDTO=telegramBotActionDTO;
            TelegramBotId=telegramBotId;
        }

        public TelegramBotActionDTO TelegramBotActionDTO { get; }
        public Guid TelegramBotId { get; }
    }
}
