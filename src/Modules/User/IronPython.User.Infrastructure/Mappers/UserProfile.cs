using AutoMapper;
using IronPython.User.Contracts;

namespace IronPython.User.Infrastructure.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            
            CreateMap<User.Domain.Entities.User, UserDTO>();
            CreateMap<UserDTO, User.Domain.Entities.User>();
            CreateMap<CreateUserDTO, User.Domain.Entities.User>();
            CreateMap<User.Domain.Entities.User, CreateUserDTO>();
        }
    }
}
