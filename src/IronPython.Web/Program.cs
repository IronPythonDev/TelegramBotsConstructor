using IronPython.Api.GoogleAuthorization;
using IronPython.TelegramBots.Application.QueryHandlers;
using IronPython.TelegramBots.Domain;
using IronPython.TelegramBots.Infrastructure;
using IronPython.TelegramBots.Infrastructure.ActionTasks;
using IronPython.TelegramBots.Infrastructure.ActionTriggers;
using IronPython.TelegramBots.Infrastructure.Domain;
using IronPython.TelegramBots.Infrastructure.Services;
using IronPython.User.Application.QueryHandlers;
using IronPython.User.Domain;
using IronPython.User.Infrastructure;
using IronPython.User.Infrastructure.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddControllers();

builder.Services.AddSingleton<TriggerCache>((p) =>
{
    var cache = new TriggerCache(p);

    cache.Load(typeof(UserMessageEqualTriggerHandler).Assembly);

    return cache;
});

builder.Services.AddSingleton<TaskCache>((p) =>
{
    var cache = new TaskCache(p);

    cache.Load(typeof(SendMessageTaskHandler).Assembly);

    return cache;
});

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ITelegramBotsRepository, TelegramBotsRepository>();

builder.Services.AddMediatR(
    typeof(CreateUserQueryHandler).Assembly,
    typeof(CreateTelegramBotQueryHandler).Assembly);

builder.Services.AddAutoMapper(
    typeof(IronPython.User.Infrastructure.Mappers.UserProfile).Assembly,
    typeof(IronPython.TelegramBots.Infrastructure.Mappers.TelegramBotsProfile).Assembly);

builder.Services
    .AddAuthentication(op => op.DefaultScheme = AuthenticationBuilderExtensions.GoogleAuthScheme)
    .AddIronGoogle();

#region DbContexts
var connectionString = builder.Configuration.GetConnectionString("Postgres");

builder.Services.AddDbContext<UserContext>(p => p
    .UseNpgsql(connectionString, p => p.MigrationsAssembly("IronPython.Migrator.User")), ServiceLifetime.Transient);

builder.Services.AddDbContext<TelegramBotsContext>(p => p
    .UseNpgsql(connectionString, p => p.MigrationsAssembly("IronPython.Migrator.TelegramBots")), ServiceLifetime.Transient);
#endregion

var app = builder.Build();

#region Migrate DbContexts
using var scope = app.Services.CreateScope();

scope.ServiceProvider.GetRequiredService<UserContext>().Database.Migrate();
scope.ServiceProvider.GetRequiredService<TelegramBotsContext>().Database.Migrate();
#endregion

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();