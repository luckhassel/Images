using ImagesStorage.Domain.Entities;

namespace ImagesStorage.Domain.Interfaces.Repositories
{
    public interface IImageRepository
    {
        ImageEntity Get(int id);
        void Set (ImageEntity entity);
        IEnumerable<ImageEntity> All();
    }
}