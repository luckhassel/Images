using ImagesStorage.Application.Models;
using ImagesStorage.Application.Models.ViewModels;

namespace ImagesStorage.Application.Interfaces
{
    public interface IImagesService
    {
        ResultViewModel<ImageViewModel> Get(int id);
        ResultViewModel Set (ImageDTO dto);
        ResultViewModel<IEnumerable<ImageViewModel>> All();
    }
}