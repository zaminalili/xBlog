using Microsoft.EntityFrameworkCore;
using xBlog.API.Data;
using xBlog.API.Models.Domains;

namespace xBlog.API.Repositories
{
    public class SqlBlogRepository: IBlogRepository
    {
        private readonly xBlogDbContext dbContext;

        public SqlBlogRepository(xBlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Blog> CreateAsync(Blog blog)
        {
            await dbContext.Blogs.AddAsync(blog);
            await dbContext.SaveChangesAsync();
            return blog;
        }

        public async Task<Blog?> DeleteAsync(Guid id)
        {
            var existingBlog = await dbContext.Blogs.FirstOrDefaultAsync(b => b.Id == id);

            if (existingBlog == null)
                return null;


            dbContext.Blogs.Remove(existingBlog);

            await dbContext.SaveChangesAsync();

            return existingBlog;
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await dbContext.Blogs.ToListAsync();
        }

        public async Task<Blog?> GetByIdAsync(Guid id)
        {
            return await dbContext.Blogs.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Blog?> UpdateAsync(Guid id, Blog blog)
        {
            var existingBlog = await dbContext.Blogs.FirstOrDefaultAsync(b => b.Id == id);

            if (existingBlog == null)
                return null;

            existingBlog.Title = blog.Title;
            existingBlog.Content = blog.Content;
            existingBlog.CategoryId = blog.CategoryId;
            existingBlog.ImageUrl = blog.ImageUrl;
            existingBlog.LastEditedDate = blog.LastEditedDate;

            await dbContext.SaveChangesAsync();

            return existingBlog;
        }
    }
}
