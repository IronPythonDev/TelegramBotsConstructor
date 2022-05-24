using AutoMapper;
using IronPython.TelegramBots.Contracts.Queries;
using IronPython.TelegramBots.Domain;
using IronPython.TelegramBots.Domain.Entities;
using MediatR;

namespace IronPython.TelegramBots.Application.QueryHandlers
{
    public class AddOrUpdateTelegramBotActionTaskQueryHandler : IRequestHandler<AddOrUpdateTelegramBotActionTaskQuery>
    {
        public AddOrUpdateTelegramBotActionTaskQueryHandler(ITelegramBotsRepository telegramBotsRepository, IMapper mapper)
        {
            TelegramBotsRepository=telegramBotsRepository;
            Mapper=mapper;
        }

        public ITelegramBotsRepository TelegramBotsRepository { get; }
        public IMapper Mapper { get; }

        public async Task<Unit> Handle(AddOrUpdateTelegramBotActionTaskQuery request, CancellationToken cancellationToken)
        {
            var action = await TelegramBotsRepository.GetActionById(request.ActionId);

            await TelegramBotsRepository.AddTaskToAction(action, Mapper.Map<TelegramBotActionTask>(request.Task));

            return Unit.Value;
        }
    }
}
