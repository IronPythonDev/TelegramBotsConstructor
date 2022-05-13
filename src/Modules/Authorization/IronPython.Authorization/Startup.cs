using IronPython.Authorization.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IronPython.Authorization
{
    public class Startup : IStartup
    {
        public void Configure(IApplicationBuilder app) { }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AuthorizationContext>(p => p.UseNpgsql("Host=postgres;Database=ironpython.co;Username=postgres;Password=1111"));

            return null!;
        }
    }
}
