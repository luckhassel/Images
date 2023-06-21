using ImagesStorage.Domain.Entities;
using ImagesStorage.Domain.Interfaces.Repositories;
using ImagesStorage.Infra.Contexts;

namespace ImagesStorage.Infra.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly ApplicationContext _context;
        public ImageRepository(ApplicationContext context)
        {
            _context = context;
        }
        public IEnumerable<ImageEntity> All()
        {
            return _context
                .Set<ImageEntity>()
                .ToList();
        }

        public ImageEntity Get(int id)
        {
            return _context
                .Set<ImageEntity>()
                .FirstOrDefault(i => i.Id == id);
        }

        public void Set(ImageEntity entity)
        {
            _context
                .Set<ImageEntity>()
                .Add(entity);

            _context.SaveChanges();
        }
    }
}