using System.Text.Json;
using Telegram.Bot.Types;

namespace IronPython.TelegramBots.Infrastructure.ActionTasks
{
    public abstract class BaseTaskHandler : Handler
    {
        protected BaseTaskHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public abstract Task Handle(Update update, JsonDocument @params);
    }
}
