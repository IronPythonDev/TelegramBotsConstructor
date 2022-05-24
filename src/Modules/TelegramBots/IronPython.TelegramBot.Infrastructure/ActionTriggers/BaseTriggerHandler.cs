using System.Text.Json;
using Telegram.Bot.Types;

namespace IronPython.TelegramBots.Infrastructure.ActionTriggers
{
    public abstract class BaseTriggerHandler : Handler
    {
        protected BaseTriggerHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public abstract Task<bool> IsNext(Update update, JsonDocument @params);
    }
}
