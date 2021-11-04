
using BackOfficeAuthService.Models.DTO;
using BackOfficeAuthService.Models.Requests;

namespace BackOfficeAuthService.Repos
{
    public interface IAuthRepo
    {
        AuthDTO Login(string email, string password);
        AuthDTO Register(RegisterRequest registerRequest);
    }
}