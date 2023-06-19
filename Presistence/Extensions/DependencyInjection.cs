

using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Presistence.Extensions
{
    public static class DependencyInjection
    {
        public static void AddPresistence(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<EShopDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("constr"),
            x => x.MigrationsAssembly(typeof(EShopDbContext).Assembly.FullName)));
            services.AddScoped<EShopDbContext>();
        }
    }
}
