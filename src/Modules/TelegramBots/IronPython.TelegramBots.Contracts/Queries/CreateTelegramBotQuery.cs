using IronPython.TelegramBots.Contracts.DTOs;
using MediatR;

namespace IronPython.TelegramBots.Contracts.Queries
{
    public class CreateTelegramBotQuery : IRequest<TelegramBotDTO>
    {
        public CreateTelegramBotQuery(TelegramBotDTO telegramBot, Guid ownerId)
        {
            TelegramBot=telegramBot;
            OwnerId=ownerId;
        }

        public TelegramBotDTO TelegramBot { get; }
        public Guid OwnerId { get; }
    }
}
