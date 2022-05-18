using IronPython.TelegramBots.Infrastructure;
using IronPython.User.Application.QueryHandlers;
using IronPython.User.Domain;
using IronPython.User.Infrastructure;
using IronPython.User.Infrastructure.Domain;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpClient();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddMediatR(typeof(CreateUserQueryHandler).Assembly);
builder.Services.AddAutoMapper(typeof(IronPython.User.Infrastructure.Mappers.UserProfile).Assembly);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["JWTConfig:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JWTConfig:Audience"],
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTConfig:Key"])),
            ValidateIssuerSigningKey = true,
        };
    });

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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();