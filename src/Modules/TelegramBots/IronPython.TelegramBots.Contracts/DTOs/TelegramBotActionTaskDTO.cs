using System.Text.Json;

namespace IronPython.TelegramBots.Contracts.DTOs
{
    public class TelegramBotActionTaskDTO
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public JsonDocument Params { get; set; }
    }
}
