using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Azure;

namespace ImagesStorage.Application.DependencyInjection
{
    public static class AzureDI
    {
        public static void AddAzureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAzureClients(options => options.AddBlobServiceClient(configuration.GetConnectionString("BlobConnection")));
        }
    }
}