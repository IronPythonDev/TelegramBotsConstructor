using IronPython.Authorization.Core.Interfaces;
using IronPython.Authorization.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace IronPython.Authorization
{
    public class Startup : IStartup
    {
        public void Configure(IApplicationBuilder app) { }

        public IServiceProvider ConfigureServices(IServiceCollection services) => services
            .AddSingleton<IGoogleService, GoogleService>()
            .BuildServiceProvider();
    }
}
