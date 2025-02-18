using MyWebsite.AuthAPI.Entities;

namespace MyWebsite.AuthAPI.Services
{
    public interface IJwtTokenService
    {
        Task<string> GenerateTokenAsync(ApplicationUser user, IList<string> roles);
    }
}
