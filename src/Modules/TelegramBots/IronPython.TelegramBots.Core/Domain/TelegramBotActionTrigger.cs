using System.Text.Json;

namespace IronPython.TelegramBots.Core.Domain
{
    public class TelegramBotActionTrigger : IDisposable
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = "Unknown";
        public JsonDocument? Params { get; set; }
        public Guid TelegramBotActionId { get; set; }

        public TelegramBotAction? TelegramBotAction { get; set; }

        public void Dispose() => Params?.Dispose();
    }
}
