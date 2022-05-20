using AutoMapper;
using IronPython.User.Contracts.DTOs;
using IronPython.User.Contracts.Queries;
using IronPython.User.Domain;
using MediatR;

namespace IronPython.User.Application.QueryHandlers
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserDTO>
    {
        public GetUserByEmailQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            UserRepository=userRepository;
            Mapper=mapper;
        }

        public IUserRepository UserRepository { get; }
        public IMapper Mapper { get; }

        public async Task<UserDTO> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken) =>
            Mapper.Map<UserDTO>(await UserRepository.GetUserByEmailAsync(request.Email));
    }
}
