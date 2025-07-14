using NetFilmx_Service.Dtos.User;

namespace NetFilmx_API.Services
{
    public interface IJwtService
    {
        string GenerateToken(UserDetailsDto user);
        int? GetUserIdFromToken(string token);
    }
}