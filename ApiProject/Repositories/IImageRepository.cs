namespace ApiProject.Repositories
{
    public interface IImageRepository
    {
        Task<MyImage> GetImageAsync(Guid id);
        Task<IEnumerable<MyImage>> GetImagesAsync();
        Task AddImageAsync(MyImage image);
    }
}
