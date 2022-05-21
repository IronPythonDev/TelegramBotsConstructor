using IronPython.TelegramBots.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IronPython.TelegramBots.Infrastructure
{
    public class TelegramBotsContext : DbContext
    {
        public DbSet<TelegramBot> TelegramBots { get; set; }
        public DbSet<TelegramBotOwner> TelegramBotsOwners { get; set; }
        public DbSet<TelegramBotAction> TelegramBotsActions { get; set; }
        public DbSet<TelegramBotActionTask> TelegramBotsActionTasks { get; set; }
        public DbSet<TelegramBotActionTrigger> TelegramBotsActionTriggers { get; set; }

        public TelegramBotsContext(DbContextOptions<TelegramBotsContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("telegramBots");

            modelBuilder.Entity<TelegramBot>(entity =>
            {
                entity.ToTable("TelegramBots");
                entity.Property(p => p.Id).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(p => p.Name).HasMaxLength(128);
                entity.Property(p => p.Name).HasDefaultValue("Unknown Name!");
                entity.Property(p => p.Name).IsRequired();
            });

            modelBuilder.Entity<TelegramBotOwner>(entity =>
            {
                entity.ToTable("TelegramBotsOwners");
                entity.Property(p => p.Id).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(p => p.TelegramBotId);
                entity.Property(p => p.OwnerId);

                entity
                    .HasOne(p => p.TelegramBot)
                    .WithMany(p => p.Owners)
                    .HasForeignKey(p => p.TelegramBotId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TelegramBotAction>(entity =>
            {
                entity.ToTable("TelegramBotsActions");
                entity.Property(p => p.Id).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(p => p.Name).HasMaxLength(24);
                entity.Property(p => p.Name).HasDefaultValue("New Action!");
                entity.Property(p => p.Name).IsRequired();

                entity
                    .HasOne(p => p.TelegramBot)
                    .WithMany(p => p.Actions)
                    .HasForeignKey(p => p.TelegramBotId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TelegramBotActionTask>(entity =>
            {
                entity.ToTable("TelegramBotsActionTasks");

                entity.Property(p => p.Id).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(p => p.Type).HasDefaultValue("Unknown");
                entity.Property(p => p.Type).IsRequired();

                entity.Property(p => p.Params).HasColumnType("jsonb");

                entity
                    .HasOne(p => p.TelegramBotAction)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(p => p.TelegramBotActionId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TelegramBotActionTrigger>(entity =>
            {
                entity.ToTable("TelegramBotsActionTriggers");

                entity.Property(p => p.Id).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(p => p.Type).HasDefaultValue("Unknown");
                entity.Property(p => p.Type).IsRequired();

                entity.Property(p => p.Params).HasColumnType("jsonb");

                entity
                    .HasOne(p => p.TelegramBotAction)
                    .WithMany(p => p.Triggers)
                    .HasForeignKey(p => p.TelegramBotActionId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
