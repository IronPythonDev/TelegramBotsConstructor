namespace IronPython.TelegramBots.Domain.Entities
{
    public class TelegramBotOwner
    {
        public Guid Id { get; set; }

        public Guid TelegramBotId { get; set; }
        public Guid OwnerId { get; set; }

        public TelegramBot? TelegramBot { get; set; }
    }
}
