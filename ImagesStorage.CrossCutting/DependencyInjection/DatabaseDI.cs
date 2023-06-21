using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ImagesStorage.Infra.Contexts;

namespace ImagesStorage.Application.DependencyInjection
{
    public static class DatabaseDI
    {
        public static void AddCustomRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options => 
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"),
                    b => b.MigrationsAssembly("ImagesStorage"));
            });
        }
    }
}