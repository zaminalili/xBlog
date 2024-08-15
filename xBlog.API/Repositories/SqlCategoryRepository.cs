using Microsoft.EntityFrameworkCore;
using xBlog.API.Data;
using xBlog.API.Models.Domains;

namespace xBlog.API.Repositories
{
    public class SqlCategoryRepository : ICategoryRepository
    {
        private readonly xBlogDbContext dbContext;

        public SqlCategoryRepository(xBlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> ChangeVisibleAsync(Guid id)
        {
            var existingCategory = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (existingCategory == null)
                return null;

            
            if (existingCategory.IsVisible)
                existingCategory.IsVisible = false;
            else 
                existingCategory.IsVisible = true;
            
            await dbContext.SaveChangesAsync();

            return existingCategory;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await dbContext.Categories.Where(c => c.IsVisible == true).ToListAsync();
        }

        public async Task<List<Category>> GetAllInvisibleAsync()
        {
            return await dbContext.Categories.Where(c => c.IsVisible == false).ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category?> UpdateAsync(Guid id, Category category)
        {
            var existingCategory = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (existingCategory == null)
                return null;

            existingCategory.Name = category.Name;

            await dbContext.SaveChangesAsync();

            return existingCategory;
        }
    }
}
