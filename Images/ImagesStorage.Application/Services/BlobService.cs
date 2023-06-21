using System.Text.RegularExpressions;
using Azure.Storage.Blobs;
using ImagesStorage.Application.Interfaces;
using ImagesStorage.Application.Settings;

namespace ImagesStorage.Application.Services
{
    public partial class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly Configuration _settings;

        public BlobService(BlobServiceClient blobServiceClient, Configuration settings)
        {
            _blobServiceClient = blobServiceClient;
            _settings = settings;
        }

        public string Upload(string base64Image)
        {
            var fileName = Guid.NewGuid().ToString() + ".jpg";

            var data = ImageRegex().Replace(base64Image, "");

            byte[] imageBytes = Convert.FromBase64String(data);

            var containerClient = _blobServiceClient.GetBlobContainerClient(_settings.BlobStorageSettings.Container); 

            using var stream = new MemoryStream(imageBytes);
            containerClient.UploadBlob(fileName, stream);

            return $"{_blobServiceClient.Uri.AbsoluteUri}{_settings.BlobStorageSettings.Container}/{fileName}";
        }

        [GeneratedRegex("^data:image\\/[a-z]+;base64,")]
        private static partial Regex ImageRegex();
    }
}