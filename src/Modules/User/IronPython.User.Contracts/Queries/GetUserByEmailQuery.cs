using IronPython.User.Contracts.DTOs;
using MediatR;

namespace IronPython.User.Contracts.Queries
{
    public class GetUserByEmailQuery : IRequest<UserDTO>
    {
        public GetUserByEmailQuery(string email)
        {
            Email=email;
        }

        public string Email { get; }
    }
}
