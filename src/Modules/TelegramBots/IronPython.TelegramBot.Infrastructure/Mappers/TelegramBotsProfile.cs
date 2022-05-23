using AutoMapper;
using IronPython.TelegramBots.Contracts.DTOs;
using IronPython.TelegramBots.Domain.Entities;

namespace IronPython.TelegramBots.Infrastructure.Mappers
{
    public class TelegramBotsProfile : Profile
    {
        public TelegramBotsProfile()
        {
            CreateMap<TelegramBot, TelegramBotDTO>();
            CreateMap<TelegramBotDTO, TelegramBot>();
        }
    }
}
