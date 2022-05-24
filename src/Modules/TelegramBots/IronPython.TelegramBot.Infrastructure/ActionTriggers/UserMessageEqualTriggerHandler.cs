using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.Bot.Types;

namespace IronPython.TelegramBots.Infrastructure.ActionTriggers
{
    public class UserMessageEqualTriggerParams
    {
        [JsonPropertyName("text")] public string Text { get; set; }
    }

    [ActionTrigger("user_message_equal")]
    public class UserMessageEqualTriggerHandler : BaseTriggerHandler
    {
        public UserMessageEqualTriggerHandler(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public override Task<bool> IsNext(Update update, JsonDocument @params)
        {
            var _params = @params.Deserialize<UserMessageEqualTriggerParams>();

            return Task.FromResult(update.Message!.Text == _params!.Text);
        }
    }
}
