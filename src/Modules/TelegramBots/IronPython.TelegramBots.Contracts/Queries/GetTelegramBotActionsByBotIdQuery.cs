using IronPython.TelegramBots.Contracts.DTOs;
using MediatR;

namespace IronPython.TelegramBots.Contracts.Queries
{
    public class GetTelegramBotActionsByBotIdQuery : IRequest<IList<TelegramBotActionDTO>>
    {
        public GetTelegramBotActionsByBotIdQuery(Guid telegramBotId)
        {
            TelegramBotId=telegramBotId;
        }

        public Guid TelegramBotId { get; }
    }
}
