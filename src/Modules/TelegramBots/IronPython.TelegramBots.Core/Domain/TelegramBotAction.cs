namespace IronPython.TelegramBots.Core.Domain
{
    public class TelegramBotAction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid TelegramBotId { get; set; }

        public TelegramBot? TelegramBot { get; set; }

        public IList<TelegramBotActionTask> Tasks { get; set; } = new List<TelegramBotActionTask>();
        public IList<TelegramBotActionTrigger> Triggers { get; set; } = new List<TelegramBotActionTrigger>();
    }
}
