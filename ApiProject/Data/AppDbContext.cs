using Microsoft.EntityFrameworkCore;

namespace ApiProject.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<MyImage> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=app.db");
        }
    }
}
