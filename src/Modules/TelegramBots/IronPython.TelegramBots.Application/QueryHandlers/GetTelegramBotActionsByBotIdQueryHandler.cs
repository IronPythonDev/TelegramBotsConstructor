using AutoMapper;
using IronPython.TelegramBots.Contracts.DTOs;
using IronPython.TelegramBots.Contracts.Queries;
using IronPython.TelegramBots.Domain;
using MediatR;

namespace IronPython.TelegramBots.Application.QueryHandlers
{
    public class GetTelegramBotActionsByBotIdQueryHandler : IRequestHandler<GetTelegramBotActionsByBotIdQuery, IList<TelegramBotActionDTO>>
    {
        public GetTelegramBotActionsByBotIdQueryHandler(ITelegramBotsRepository telegramBotsRepository, IMapper mapper)
        {
            TelegramBotsRepository=telegramBotsRepository;
            Mapper=mapper;
        }

        public ITelegramBotsRepository TelegramBotsRepository { get; }
        public IMapper Mapper { get; }

        public async Task<IList<TelegramBotActionDTO>> Handle(GetTelegramBotActionsByBotIdQuery request, CancellationToken cancellationToken)
        {
            return Mapper.Map<IList<TelegramBotActionDTO>>(await TelegramBotsRepository.GetActionsByTelegramBotId(request.TelegramBotId));
        }
    }
}
