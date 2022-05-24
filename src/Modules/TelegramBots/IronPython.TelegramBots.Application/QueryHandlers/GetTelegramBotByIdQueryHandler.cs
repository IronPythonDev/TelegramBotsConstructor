using AutoMapper;
using IronPython.TelegramBots.Contracts.DTOs;
using IronPython.TelegramBots.Contracts.Queries;
using IronPython.TelegramBots.Domain;
using MediatR;

namespace IronPython.TelegramBots.Application.QueryHandlers
{
    public class GetTelegramBotByIdQueryHandler : IRequestHandler<GetTelegramBotByIdQuery, TelegramBotDTO>
    {
        public GetTelegramBotByIdQueryHandler(ITelegramBotsRepository telegramBotsRepository, IMapper mapper)
        {
            TelegramBotsRepository=telegramBotsRepository;
            Mapper=mapper;
        }

        public ITelegramBotsRepository TelegramBotsRepository { get; }
        public IMapper Mapper { get; }

        public async Task<TelegramBotDTO> Handle(GetTelegramBotByIdQuery request, CancellationToken cancellationToken)
        {
            return Mapper.Map<TelegramBotDTO>(await TelegramBotsRepository.GetByIdAsync(request.Id));
        }
    }
}
