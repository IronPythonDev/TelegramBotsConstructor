using AutoMapper;
using IronPython.TelegramBots.Contracts.DTOs;
using IronPython.TelegramBots.Contracts.Queries;
using IronPython.TelegramBots.Domain;
using IronPython.TelegramBots.Domain.Entities;
using MediatR;

namespace IronPython.TelegramBots.Application.QueryHandlers
{
    public class CreateTelegramBotQueryHandler : IRequestHandler<CreateTelegramBotQuery, TelegramBotDTO>
    {
        public CreateTelegramBotQueryHandler(ITelegramBotsRepository telegramBotsRepository, IMapper mapper)
        {
            TelegramBotsRepository=telegramBotsRepository;
            Mapper=mapper;
        }

        public ITelegramBotsRepository TelegramBotsRepository { get; }
        public IMapper Mapper { get; }

        public async Task<TelegramBotDTO> Handle(CreateTelegramBotQuery request, CancellationToken cancellationToken)
        {
            var newBotEntity = await TelegramBotsRepository.CreateAsync(Mapper.Map<TelegramBot>(request.TelegramBot));

            await TelegramBotsRepository.AddOwnerToTelegramBot(newBotEntity, request.OwnerId);

            return Mapper.Map<TelegramBotDTO>(newBotEntity);
        }
    }
}
