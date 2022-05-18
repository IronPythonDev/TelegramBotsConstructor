using MediatR;

namespace IronPython.User.Contracts.Queries
{
    public class CreateUserQuery : IRequest<UserDTO>
    {
        public CreateUserQuery(CreateUserDTO user)
        {
            User=user;
        }

        public CreateUserDTO User { get; }
    }
}