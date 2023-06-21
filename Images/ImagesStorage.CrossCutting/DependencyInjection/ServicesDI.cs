using ImagesStorage.Application.Interfaces;
using ImagesStorage.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ImagesStorage.Application.DependencyInjection
{
    public static class ServicesDI
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            services.AddScoped<IBlobService, BlobService>();
            services.AddScoped<IImagesService, ImagesService>();
        }
    }
}