using System.Text.Json;
using Telegram.Bot.Types;

namespace IronPython.TelegramBots.Infrastructure.ActionTasks
{
    [ActionTask("send_message")]
    public class SendMessageTaskHandler : BaseTaskHandler
    {
        public SendMessageTaskHandler(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public override Task Handle(Update update, JsonDocument @params)
        {
            return Task.CompletedTask;
        }
    }
}
