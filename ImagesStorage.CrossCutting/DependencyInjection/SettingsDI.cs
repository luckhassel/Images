using ImagesStorage.Application.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ImagesStorage.Application.DependencyInjection
{
    public static class SettingsDI
    {
        public static void AddCustomSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = new Configuration();
            configuration.GetSection(Configuration.SECTION).Bind(settings);

            services.AddSingleton(settings);
        }
    }
}