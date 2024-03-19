
using ApiProject.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Repositories
{

    public class ImageRepository:IImageRepository
    {
        private readonly AppDbContext _context;
        public ImageRepository()
        {
            _context = new AppDbContext();
            _context.Database.EnsureCreated();
        }

        public async Task AddImageAsync(MyImage image)
        {
            if(image is not null)
            {
                await _context.Images.AddAsync(image);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<MyImage> GetImageAsync(Guid id)
        {
            var result = await _context.Images.FindAsync(id);
            return result;
        }

        public async Task<IEnumerable<MyImage>> GetImagesAsync()
        {
            return await _context.Images.ToListAsync();
        }
    }
}
