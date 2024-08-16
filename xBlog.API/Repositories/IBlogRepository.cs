using xBlog.API.Models.Domains;

namespace xBlog.API.Repositories
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllAsync();
        Task<Blog?> GetByIdAsync(Guid id);
        Task<Blog> CreateAsync(Blog blog);
        Task<Blog?> UpdateAsync(Guid id, Blog blog);
        Task<Blog?> DeleteAsync(Guid id);
    }
}
