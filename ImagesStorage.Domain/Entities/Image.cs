namespace ImagesStorage.Domain.Entities
{
    public class ImageEntity
    {
        public int Id { get; }
        public string Url { get; }
        private ImageEntity(string url)
        {
            Url = url;
        }

        public static ImageEntity? Create(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return null;

            return new ImageEntity(url);
        }

        public ImageEntity()
        {
            
        }
    }
}