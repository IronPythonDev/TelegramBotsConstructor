using Microsoft.EntityFrameworkCore;

namespace IronPython.Authorization.Infrastructure
{
    public class AuthorizationContext : DbContext
    {
        public AuthorizationContext(DbContextOptions<AuthorizationContext> options) : base(options)
        {
            
        }
    }
}
