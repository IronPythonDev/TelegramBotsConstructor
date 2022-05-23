using IronPython.User.Domain;
using Microsoft.EntityFrameworkCore;

namespace IronPython.User.Infrastructure.Domain
{
    public class UserRepository : IUserRepository

    {
        public UserRepository(UserContext context)
        {
            Context = context;
        }

        public UserContext Context { get; }

        public async Task<User.Domain.Entities.User> CreateAsync(User.Domain.Entities.User entity)
        {
            var result = await Context.Users.AddAsync(entity);

            await Context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task DeleteAsync(User.Domain.Entities.User entity)
        {
            Context.Users.Remove(entity);

            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context?.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<User.Domain.Entities.User> GetByIdAsync(Guid id)
        {
            return await Context.Users.FirstAsync(p => p.Id == id);
        }

        public async Task<User.Domain.Entities.User> GetUserByEmailAsync(string email) =>
            await Context.Users.FirstAsync(p => p.Email == email);

        public Task RegenerateRefreshTokenForUserAsync(User.Domain.Entities.User user)
        {
            Context.Users.FromSqlRaw(@"UPDATE ""user"".""Users"" SET ""RefreshToken""=md5(random()::text) WHERE ""Id"" = @id;", new
            {
                id = user.Id,
            });

            return Task.CompletedTask;
        }

        public async Task UpdateAsync(User.Domain.Entities.User entity)
        {
            Context.Users.Update(entity);

            await Context.SaveChangesAsync();
        }
    }
}
