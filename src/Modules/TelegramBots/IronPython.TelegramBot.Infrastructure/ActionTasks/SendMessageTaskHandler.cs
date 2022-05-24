using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace IronPython.TelegramBots.Infrastructure.ActionTasks
{
    public class SendMessageTaskParams
    {
        [JsonPropertyName("text")] public string Text { get; set; }
    }

    [ActionTask("send_message")]
    public class SendMessageTaskHandler : BaseTaskHandler
    {
        public SendMessageTaskHandler(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public override async Task Handle(Update update, ITelegramBotClient client, JsonDocument @params)
        {
            var _params = @params.Deserialize<SendMessageTaskParams>();

            await client.SendTextMessageAsync(
                chatId: update.Message!.Chat.Id,
                text: _params!.Text);
        }
    }
}
