using AutoMapper;
using IronPython.TelegramBots.Contracts.Queries;
using IronPython.TelegramBots.Domain;
using IronPython.TelegramBots.Domain.Entities;
using MediatR;

namespace IronPython.TelegramBots.Application.QueryHandlers
{
    public class AddOrUpdateTelegramBotActionTriggerQueryHandler : IRequestHandler<AddOrUpdateTelegramBotActionTriggerQuery>
    {
        public AddOrUpdateTelegramBotActionTriggerQueryHandler(ITelegramBotsRepository telegramBotsRepository, IMapper mapper)
        {
            TelegramBotsRepository=telegramBotsRepository;
            Mapper=mapper;
        }

        public ITelegramBotsRepository TelegramBotsRepository { get; }
        public IMapper Mapper { get; }

        public async Task<Unit> Handle(AddOrUpdateTelegramBotActionTriggerQuery request, CancellationToken cancellationToken)
        {
            var action = await TelegramBotsRepository.GetActionById(request.ActionId);

            await TelegramBotsRepository.AddTriggerToAction(action, Mapper.Map<TelegramBotActionTrigger>(request.Trigger));

            return Unit.Value;
        }
    }
}
