using IronPython.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace IronPython.Authorization.Infrastructure
{
    public class AuthorizationContext : DbContext
    {
        public static bool IsCreated = false;

        public AuthorizationContext(DbContextOptions<AuthorizationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(p => p.Id).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(p => p.RefreshToken).HasDefaultValueSql("md5(random()::text)");
                entity.Property(p => p.Email).IsRequired();
                entity.Property(p => p.Email).HasMaxLength(128);
            });
        }
    }
}
