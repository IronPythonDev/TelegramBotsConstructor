using AutoMapper;
using IronPython.User.Contracts;
using IronPython.User.Contracts.Queries;
using IronPython.User.Domain;
using MediatR;

namespace IronPython.User.Application.QueryHandlers
{
    public class CreateUserQueryHandler : IRequestHandler<CreateUserQuery, UserDTO>
    {
        public CreateUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            UserRepository=userRepository;
            Mapper=mapper;
        }

        public IUserRepository UserRepository { get; }
        public IMapper Mapper { get; }

        public async Task<UserDTO> Handle(CreateUserQuery request, CancellationToken cancellationToken)
        {
            var newUser = await UserRepository.CreateAsync(Mapper.Map<CreateUserDTO, Domain.Entities.User>(request.User));

            return Mapper.Map<UserDTO>(newUser);
        }
    }
}
