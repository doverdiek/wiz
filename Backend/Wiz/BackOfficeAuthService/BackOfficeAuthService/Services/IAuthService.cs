
using BackOfficeAuthService.Models.DTO;
using BackOfficeAuthService.Models.Requests;

namespace BackOfficeAuthService.Services
{
    public interface IAuthService
    {
        AuthDTO Login(string email, string password);
        AuthDTO Register(RegisterRequest registerRequest);
    }
}