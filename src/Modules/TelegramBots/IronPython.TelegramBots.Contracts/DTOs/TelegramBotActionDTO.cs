namespace IronPython.TelegramBots.Contracts.DTOs
{
    public class TelegramBotActionDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IList<TelegramBotActionTriggerDTO> Triggers { get; set; } = new List<TelegramBotActionTriggerDTO>();
        public IList<TelegramBotActionTaskDTO> Tasks { get; set; } = new List<TelegramBotActionTaskDTO>();
    }
}
