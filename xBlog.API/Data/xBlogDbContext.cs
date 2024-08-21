using Microsoft.EntityFrameworkCore;
using xBlog.API.Models.Domains;

namespace xBlog.API.Data
{
    public class xBlogDbContext: DbContext
    {
        public xBlogDbContext(DbContextOptions<xBlogDbContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
