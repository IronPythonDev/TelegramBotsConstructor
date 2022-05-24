using MediatR;

namespace IronPython.TelegramBots.Contracts.Queries
{
    public class StopTelegramBotQuery : IRequest
    {
        public StopTelegramBotQuery(Guid id)
        {
            Id=id;
        }

        public Guid Id { get; }
    }
}
