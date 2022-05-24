using Telegram.Bot.Types;

namespace IronPython.TelegramBots.Infrastructure
{
    public abstract class Handler
    {
        public Handler(IServiceProvider serviceProvider)
        {
            ServiceProvider=serviceProvider;
        }

        IServiceProvider ServiceProvider { get; }
    }
}
