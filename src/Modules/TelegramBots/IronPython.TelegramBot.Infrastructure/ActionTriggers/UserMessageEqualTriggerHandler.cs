using System.Text.Json;
using Telegram.Bot.Types;

namespace IronPython.TelegramBots.Infrastructure.ActionTriggers
{
    [ActionTrigger("user_message_equal")]
    public class UserMessageEqualTriggerHandler : BaseTriggerHandler
    {
        public UserMessageEqualTriggerHandler(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public override Task<bool> IsNext(Update update, JsonDocument @params)
        {
            return Task.FromResult(true);
        }
    }
}
