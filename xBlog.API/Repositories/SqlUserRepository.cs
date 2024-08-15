using Microsoft.EntityFrameworkCore;
using xBlog.API.Data;
using xBlog.API.Models.Domains;

namespace xBlog.API.Repositories
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly xBlogDbContext dbContext;

        public SqlUserRepository(xBlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> CreateAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User?> DeleteAsync(Guid id)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (existingUser == null)
                return null;


            dbContext.Users.Remove(existingUser);

            await dbContext.SaveChangesAsync();

            return existingUser;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await dbContext.Users.ToListAsync();

        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> UpdateAsync(Guid id, User user)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (existingUser == null)
                return null;

            existingUser.Username = user.Username;
            existingUser.Password = user.Password;
            existingUser.Email = user.Email;

            await dbContext.SaveChangesAsync();

            return existingUser;
        }
    }
}
