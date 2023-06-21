using ImagesStorage.Application.Interfaces;
using ImagesStorage.Application.Models;
using ImagesStorage.Application.Models.ViewModels;
using ImagesStorage.Domain.Entities;
using ImagesStorage.Domain.Interfaces.Repositories;

namespace ImagesStorage.Application.Services
{
    public class ImagesService : IImagesService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IBlobService _blobService;
        public ImagesService(IImageRepository imageRepository, IBlobService blobService)
        {
            _imageRepository = imageRepository;
            _blobService = blobService;
        }

        public ResultViewModel<IEnumerable<ImageViewModel>> All()
        {
            ResultViewModel<IEnumerable<ImageViewModel>> result = new();
            List<ImageViewModel> resultData = new();
            var entities = _imageRepository.All();

            if (entities is null)
                return result;

            foreach(var entity in entities)
            {
                resultData.Add(new ImageViewModel{ Url = entity.Url });
            }

            result.Result = resultData;

            return result;
        }

        public ResultViewModel<ImageViewModel> Get(int id)
        {
            var result = new ResultViewModel<ImageViewModel>();
            var entity = _imageRepository.Get(id);

            if (entity is not null)
                result.Result.Url = entity.Url;
            else
                result.ValidationResult = ValidationResult.SetValidationResultError("Image not found", 0);

            return result;
        }

        public ResultViewModel Set(ImageDTO dto)
        {
            var result = new ResultViewModel();
            var uploadImageUrl = _blobService.Upload(dto.Base64Image);

            if (string.IsNullOrWhiteSpace(uploadImageUrl))
            {
                result.ValidationResult = ValidationResult.SetValidationResultError("Error uploading image", 1);
                return result;
            }

            var entity = ImageEntity.Create(uploadImageUrl);

            if (entity is null)
            {
                result.ValidationResult = ValidationResult.SetValidationResultError("Error uploading image", 2);
                return result;
            }

            _imageRepository.Set(entity);

            return result;
        }
    }
}