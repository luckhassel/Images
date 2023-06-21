using ImagesStorage.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ImagesStorage.Infra.Configurations.Mappings
{
    public static class ImageMapping
    {
        public static void ConfigureImageMapping(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImageEntity>(i => 
            {
                i.ToTable("Image");
                i.HasKey(i => i.Id);
                i.Property(i => i.Url);
            });
        }
    }
}