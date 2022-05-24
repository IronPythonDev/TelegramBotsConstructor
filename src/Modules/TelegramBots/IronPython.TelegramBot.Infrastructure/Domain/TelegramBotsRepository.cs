using IronPython.TelegramBots.Domain;
using IronPython.TelegramBots.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IronPython.TelegramBots.Infrastructure.Domain
{
    public class TelegramBotsRepository : ITelegramBotsRepository
    {
        public TelegramBotsRepository(TelegramBotsContext context)
        {
            Context=context;
        }

        public TelegramBotsContext Context { get; }

        public async Task AddActionToTelegramBot(TelegramBot telegramBot, TelegramBotAction action)
        {
            action.TelegramBot = telegramBot;

            await Context.TelegramBotsActions.AddAsync(action);

            await Context.SaveChangesAsync();
        }

        public async Task AddOwnerToTelegramBot(TelegramBot telegramBot, Guid ownerId)
        {
            await Context.TelegramBotsOwners.AddAsync(new TelegramBotOwner
            {
                TelegramBot = telegramBot,
                OwnerId = ownerId,
            });

            await Context.SaveChangesAsync();
        }

        public async Task AddTaskToAction(TelegramBotAction action, TelegramBotActionTask task)
        {
            task.TelegramBotAction = action;

            await Context.TelegramBotsActionTasks.AddAsync(task);

            await Context.SaveChangesAsync();
        }

        public async Task AddTriggerToAction(TelegramBotAction action, TelegramBotActionTrigger trigger)
        {
            trigger.TelegramBotAction = action;

            await Context.TelegramBotsActionTriggers.AddAsync(trigger);

            await Context.SaveChangesAsync();
        }

        public async Task<TelegramBot> CreateAsync(TelegramBot entity)
        {
            var newEntity = await Context.TelegramBots.AddAsync(entity);

            await Context.SaveChangesAsync();

            return newEntity.Entity;
        }

        public async Task DeleteAsync(TelegramBot entity)
        {
            Context.TelegramBots.Remove(entity);

            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<TelegramBotAction> GetActionById(Guid id) =>
            await Context.TelegramBotsActions.Include(p => p.Tasks).Include(p => p.Triggers).FirstAsync(p => p.Id == id);

        public async Task<TelegramBot> GetByIdAsync(Guid id) =>
            await Context.TelegramBots.Include(p => p.Actions).FirstAsync(p => p.Id == id);

        public async Task UpdateAsync(TelegramBot entity)
        {
            Context.TelegramBots.Update(entity);

            await Context.SaveChangesAsync();
        }
    }
}
