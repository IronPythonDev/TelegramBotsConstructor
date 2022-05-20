using IronPython.Domain;

namespace IronPython.User.Domain
{
    public interface IUserRepository : IRepository<Entities.User>
    {
        Task<Entities.User> GetUserByEmailAsync(string email);
        Task RegenerateRefreshTokenForUserAsync(Entities.User user);
    }
}
