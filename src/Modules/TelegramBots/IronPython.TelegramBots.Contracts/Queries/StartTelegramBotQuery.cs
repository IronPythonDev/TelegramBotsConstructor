using MediatR;

namespace IronPython.TelegramBots.Contracts.Queries
{
    public class StartTelegramBotQuery : IRequest
    {
        public StartTelegramBotQuery(Guid id)
        {
            Id=id;
        }

        public Guid Id { get; }
    }
}
