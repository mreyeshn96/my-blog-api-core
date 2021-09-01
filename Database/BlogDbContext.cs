using Microsoft.EntityFrameworkCore;

namespace my_app_backend.Database
{
    public class BlogDbContext: DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}