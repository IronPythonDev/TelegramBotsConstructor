namespace IronPython.TelegramBots.Domain.Entities
{
    public class TelegramBot
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IList<TelegramBotOwner> Owners { get; set; } = new List<TelegramBotOwner>();
        public IList<TelegramBotAction> Actions { get; set; } = new List<TelegramBotAction>();
    }
}
