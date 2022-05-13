using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace IronPython.TelegramBots
{
    public class Startup : IStartup
    {
        public void Configure(IApplicationBuilder app) { }

        public IServiceProvider ConfigureServices(IServiceCollection services) => null!;
    }
}