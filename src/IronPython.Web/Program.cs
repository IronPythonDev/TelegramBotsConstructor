var builder = WebApplication.CreateBuilder(args);

var startupsOfmodules = new List<Type>()
{
    typeof(IronPython.Authorization.Startup),
    typeof(IronPython.TelegramBots.Startup)
};

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

foreach (var startup in startupsOfmodules)
{
    var startupInstance = ((IStartup)Activator.CreateInstance(startup)!);

    startupInstance.ConfigureServices(builder.Services);

    builder.Services.AddControllers().AddApplicationPart(startup.Assembly);
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();