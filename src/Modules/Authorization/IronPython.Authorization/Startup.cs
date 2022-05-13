using IronPython.Authorization.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IronPython.Authorization
{
    public class Startup : IStartup
    {
        public void Configure(IApplicationBuilder app) { }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

            services.AddDbContext<AuthorizationContext>(p => p
                .UseNpgsql(configuration.GetConnectionString("Postgres"), p => p.MigrationsAssembly("IronPython.Migrator.Authorization")));

            services.BuildServiceProvider().GetRequiredService<AuthorizationContext>().Database.Migrate();

            return null!;
        }
    }
}
