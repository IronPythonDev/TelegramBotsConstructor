using MediatR;

namespace IronPython.User.Contracts
{
    public class CreateUserQuery : IRequest
    {
        public CreateUserQuery(Domain.User user)
        {
            User=user;
        }

        public Domain.User User { get; }
    }
}