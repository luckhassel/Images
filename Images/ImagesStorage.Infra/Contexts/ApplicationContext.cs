using ImagesStorage.Infra.Configurations.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ImagesStorage.Infra.Contexts
{
    public class ApplicationContext : DbContext
    {
        protected ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureImageMapping();
        }
    }
}