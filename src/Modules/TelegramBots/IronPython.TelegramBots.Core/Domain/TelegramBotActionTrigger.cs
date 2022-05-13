using System.Text.Json;

namespace IronPython.Core.Entities.TelegramBotEntities
{
    public class TelegramBotActionTrigger : IDisposable
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = "Unknown";
        public JsonDocument? Params { get; set; }
        public Guid TelegramBotId { get; set; }

        public void Dispose() => Params?.Dispose();
    }
}
