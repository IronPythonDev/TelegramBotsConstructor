using IronPython.Domain;
using IronPython.TelegramBots.Domain.Entities;

namespace IronPython.TelegramBots.Domain
{
    public interface ITelegramBotsRepository : IRepository<TelegramBot>
    {
        Task AddOwnerToTelegramBot(TelegramBot telegramBot, Guid ownerId);
    }
}
