using ImagesStorage.Domain.Interfaces.Repositories;
using ImagesStorage.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ImagesStorage.Application.DependencyInjection
{
    public static class RepositoryDI
    {
        public static void AddCustomRepository(this IServiceCollection services)
        {
            services.AddScoped<IImageRepository, ImageRepository>();
        }
    }
}