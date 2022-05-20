using IronPython.Api.GoogleAuthorization;
using IronPython.TelegramBots.Infrastructure;
using IronPython.User.Application.QueryHandlers;
using IronPython.User.Domain;
using IronPython.User.Infrastructure;
using IronPython.User.Infrastructure.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddControllers();

builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddMediatR(typeof(CreateUserQueryHandler).Assembly);
builder.Services.AddAutoMapper(typeof(IronPython.User.Infrastructure.Mappers.UserProfile).Assembly);

builder.Services.AddAuthentication(op => op.DefaultScheme = "GoogleAuthScheme")
    .AddScheme<GoogleAuthenticationSchemeOptions, GoogleAuthenticationHandler>("GoogleAuthScheme", op => { });

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