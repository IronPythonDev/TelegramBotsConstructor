using AutoMapper;
using IronPython.TelegramBots.Contracts.Queries;
using IronPython.TelegramBots.Domain;
using IronPython.TelegramBots.Domain.Entities;
using MediatR;

namespace IronPython.TelegramBots.Application.QueryHandlers
{
    public class AddOrUpdateTelegramBotActionQueryHandler : IRequestHandler<AddOrUpdateTelegramBotActionQuery>
    {
        public AddOrUpdateTelegramBotActionQueryHandler(ITelegramBotsRepository telegramBotsRepository, IMapper mapper)
        {
            TelegramBotsRepository=telegramBotsRepository;
            Mapper=mapper;
        }

        public ITelegramBotsRepository TelegramBotsRepository { get; }
        public IMapper Mapper { get; }

        public async Task<Unit> Handle(AddOrUpdateTelegramBotActionQuery request, CancellationToken cancellationToken)
        {
            var telegramBot = await TelegramBotsRepository.GetByIdAsync(request.TelegramBotId);

            await TelegramBotsRepository.AddActionToTelegramBot(telegramBot, Mapper.Map<TelegramBotAction>(request.TelegramBotActionDTO));

            return Unit.Value;
        }
    }
}
