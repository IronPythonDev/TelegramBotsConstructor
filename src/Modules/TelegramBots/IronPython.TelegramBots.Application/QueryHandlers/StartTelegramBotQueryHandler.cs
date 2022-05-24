using AutoMapper;
using IronPython.TelegramBots.Contracts.DTOs;
using IronPython.TelegramBots.Contracts.Queries;
using IronPython.TelegramBots.Domain;
using IronPython.TelegramBots.Infrastructure.Services;
using IronPython.TelegramBots.Infrastructure.Telegram;
using MediatR;

namespace IronPython.TelegramBots.Application.QueryHandlers
{
    public class StartTelegramBotQueryHandler : IRequestHandler<StartTelegramBotQuery>
    {
        public StartTelegramBotQueryHandler(ITelegramBotsRepository telegramBotsRepository, IMapper mapper, TaskCache taskCache, TriggerCache triggerCache)
        {
            TelegramBotsRepository=telegramBotsRepository;
            Mapper=mapper;
            TaskCache=taskCache;
            TriggerCache=triggerCache;
        }

        public ITelegramBotsRepository TelegramBotsRepository { get; }
        public IMapper Mapper { get; }
        public TaskCache TaskCache { get; }
        public TriggerCache TriggerCache { get; }

        public async Task<Unit> Handle(StartTelegramBotQuery request, CancellationToken cancellationToken)
        {
            var actions = await TelegramBotsRepository.GetActionsByTelegramBotId(request.Id);

            var bot = new TelegramBot("5391134230:AAFRGnNSYC9p_FpopQPYNKnb1Mh8KpuZPaE", Mapper.Map<IList<TelegramBotActionDTO>>(actions), TaskCache, TriggerCache);

            await bot.Start();

            return Unit.Value;
        }
    }
}
