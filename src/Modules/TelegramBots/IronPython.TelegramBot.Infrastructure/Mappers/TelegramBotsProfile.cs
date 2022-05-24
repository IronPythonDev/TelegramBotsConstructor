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

            CreateMap<TelegramBotAction, TelegramBotActionDTO>();
            CreateMap<TelegramBotActionDTO, TelegramBotAction>();

            CreateMap<TelegramBotAction, TelegramBotActionSmallDTO>();
            CreateMap<TelegramBotActionSmallDTO, TelegramBotAction>();

            CreateMap<TelegramBotActionTask, TelegramBotActionTaskDTO>();
            CreateMap<TelegramBotActionTaskDTO, TelegramBotActionTask>();

            CreateMap<TelegramBotActionTrigger, TelegramBotActionTriggerDTO>();
            CreateMap<TelegramBotActionTriggerDTO, TelegramBotActionTrigger>();
        }
    }
}
