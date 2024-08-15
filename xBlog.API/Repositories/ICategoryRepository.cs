using xBlog.API.Models.Domains;

namespace xBlog.API.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(Guid id);
        Task<Category> CreateAsync(Category category);
        Task<Category?> UpdateAsync(Guid id, Category category);
        Task<Category?> ChangeVisibleAsync(Guid id);
        Task<List<Category>> GetAllInvisibleAsync();
    }
}
