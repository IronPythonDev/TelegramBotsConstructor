﻿// <auto-generated />
using System.Text.Json;
using IronPython.TelegramBots.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IronPython.Migrator.TelegramBots.Migrations
{
    [DbContext(typeof(TelegramBotsContext))]
    [Migration("20220514105512_CreateTelegramBotsSchema")]
    partial class CreateTelegramBotsSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("telegramBots")
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("IronPython.TelegramBots.Core.Domain.TelegramBot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasDefaultValue("Unknown Name!");

                    b.HasKey("Id");

                    b.ToTable("TelegramBots", "telegramBots");
                });

            modelBuilder.Entity("IronPython.TelegramBots.Core.Domain.TelegramBotAction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(24)
                        .HasColumnType("character varying(24)")
                        .HasDefaultValue("New Action!");

                    b.Property<Guid>("TelegramBotId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TelegramBotId");

                    b.ToTable("TelegramBotsActions", "telegramBots");
                });

            modelBuilder.Entity("IronPython.TelegramBots.Core.Domain.TelegramBotActionTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<JsonDocument>("Params")
                        .HasColumnType("jsonb");

                    b.Property<Guid>("TelegramBotActionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Type")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("Unknown");

                    b.HasKey("Id");

                    b.HasIndex("TelegramBotActionId");

                    b.ToTable("TelegramBotsActionTasks", "telegramBots");
                });

            modelBuilder.Entity("IronPython.TelegramBots.Core.Domain.TelegramBotActionTrigger", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<JsonDocument>("Params")
                        .HasColumnType("jsonb");

                    b.Property<Guid>("TelegramBotActionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Type")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("Unknown");

                    b.HasKey("Id");

                    b.HasIndex("TelegramBotActionId");

                    b.ToTable("TelegramBotsActionTriggers", "telegramBots");
                });

            modelBuilder.Entity("IronPython.TelegramBots.Core.Domain.TelegramBotOwner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TelegramBotId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TelegramBotId");

                    b.ToTable("TelegramBotsOwners", "telegramBots");
                });

            modelBuilder.Entity("IronPython.TelegramBots.Core.Domain.TelegramBotAction", b =>
                {
                    b.HasOne("IronPython.TelegramBots.Core.Domain.TelegramBot", "TelegramBot")
                        .WithMany("Actions")
                        .HasForeignKey("TelegramBotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TelegramBot");
                });

            modelBuilder.Entity("IronPython.TelegramBots.Core.Domain.TelegramBotActionTask", b =>
                {
                    b.HasOne("IronPython.TelegramBots.Core.Domain.TelegramBotAction", "TelegramBotAction")
                        .WithMany("Tasks")
                        .HasForeignKey("TelegramBotActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TelegramBotAction");
                });

            modelBuilder.Entity("IronPython.TelegramBots.Core.Domain.TelegramBotActionTrigger", b =>
                {
                    b.HasOne("IronPython.TelegramBots.Core.Domain.TelegramBotAction", "TelegramBotAction")
                        .WithMany("Triggers")
                        .HasForeignKey("TelegramBotActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TelegramBotAction");
                });

            modelBuilder.Entity("IronPython.TelegramBots.Core.Domain.TelegramBotOwner", b =>
                {
                    b.HasOne("IronPython.TelegramBots.Core.Domain.TelegramBot", "TelegramBot")
                        .WithMany("Owners")
                        .HasForeignKey("TelegramBotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TelegramBot");
                });

            modelBuilder.Entity("IronPython.TelegramBots.Core.Domain.TelegramBot", b =>
                {
                    b.Navigation("Actions");

                    b.Navigation("Owners");
                });

            modelBuilder.Entity("IronPython.TelegramBots.Core.Domain.TelegramBotAction", b =>
                {
                    b.Navigation("Tasks");

                    b.Navigation("Triggers");
                });
#pragma warning restore 612, 618
        }
    }
}
