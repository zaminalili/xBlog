using Microsoft.AspNetCore.Identity;

namespace xBlog.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
