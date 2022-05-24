using IronPython.Domain;
using IronPython.TelegramBots.Domain.Entities;

namespace IronPython.TelegramBots.Domain
{
    public interface ITelegramBotsRepository : IRepository<TelegramBot>
    {
        Task<TelegramBotAction> GetActionById(Guid id);

        Task AddOwnerToTelegramBot(TelegramBot telegramBot, Guid ownerId);
        Task AddActionToTelegramBot(TelegramBot telegramBot, TelegramBotAction action);

        Task AddTriggerToAction(TelegramBotAction action, TelegramBotActionTrigger trigger);
        Task AddTaskToAction(TelegramBotAction action, TelegramBotActionTask task);
    }
}
