using IronPython.User.Contracts;
using IronPython.User.Domain;
using MediatR;

namespace IronPython.User.Application.QueryHandlers
{
    public class CreateUserQueryHandler : IRequestHandler<CreateUserQuery>
    {
        public CreateUserQueryHandler(IUserRepository userRepository)
        {
            UserRepository=userRepository;
        }

        public IUserRepository UserRepository { get; }

        Task<Unit> IRequestHandler<CreateUserQuery, Unit>.Handle(CreateUserQuery request, CancellationToken cancellationToken)
        {
            return Unit.Task;
        }
    }
}
