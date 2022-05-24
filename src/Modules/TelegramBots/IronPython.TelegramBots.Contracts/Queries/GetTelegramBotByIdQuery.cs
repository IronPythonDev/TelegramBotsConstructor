using IronPython.TelegramBots.Contracts.DTOs;
using MediatR;

namespace IronPython.TelegramBots.Contracts.Queries
{
    public class GetTelegramBotByIdQuery : IRequest<TelegramBotDTO>
    {
        public GetTelegramBotByIdQuery(Guid id)
        {
            Id=id;
        }

        public Guid Id { get; }
    }
}
