using Microsoft.EntityFrameworkCore;

namespace IronPython.User.Infrastructure
{
    public class UserContext : DbContext
    {
        public DbSet<User.Domain.User> Users { get; set; }

        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("user");

            modelBuilder.Entity<User.Domain.User>(entity =>
            {
                entity.ToTable("Users");
                entity.Property(p => p.Id).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(p => p.RefreshToken).HasDefaultValueSql("md5(random()::text)");
                entity.Property(p => p.Email).IsRequired();
                entity.Property(p => p.Email).HasMaxLength(128);
            });
        }
    }
}
