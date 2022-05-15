using IronPython.Authorization.Infrastructure;
using IronPython.TelegramBots.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

void RegisterModule(Type startupType)
{
    var startupInstance = (IStartup)Activator.CreateInstance(startupType)!;

    startupInstance.ConfigureServices(builder!.Services);

    builder.Services.AddControllers().AddApplicationPart(startupType.Assembly);
}

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

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

builder.Services.AddDbContext<AuthorizationContext>(p => p
    .UseNpgsql(connectionString, p => p.MigrationsAssembly("IronPython.Migrator.Authorization")), ServiceLifetime.Transient);

builder.Services.AddDbContext<TelegramBotsContext>(p => p
    .UseNpgsql(connectionString, p => p.MigrationsAssembly("IronPython.Migrator.TelegramBots")), ServiceLifetime.Transient);
#endregion

RegisterModule(typeof(IronPython.TelegramBots.Startup));
RegisterModule(typeof(IronPython.Authorization.Startup));

var app = builder.Build();

#region Migrate DbContexts
using var scope = app.Services.CreateScope();

scope.ServiceProvider.GetRequiredService<AuthorizationContext>().Database.Migrate();
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