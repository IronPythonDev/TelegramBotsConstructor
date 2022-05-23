namespace IronPython.TelegramBots.Contracts.DTOs
{
    public class TelegramBotDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IList<TelegramBotActionDTO> Actions { get; set; } = new List<TelegramBotActionDTO>();
    }
}
