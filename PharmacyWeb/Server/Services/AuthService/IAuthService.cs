using PharmacyWeb.Shared;
using PharmacyWeb.Shared.Models;

namespace PharmacyWeb.Server.Services.AuthService
{
    public interface IAuthService
    {
        Task<User> Login(UserLogin request);
        Task<User> Register(UserRegister request);
        Task<User> LoginGuest();

    }
}
