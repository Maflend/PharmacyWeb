using PharmacyWeb.Shared;
using PharmacyWeb.Shared.Models;

namespace PharmacyWeb.Client.Services.AuthService
{
    public interface IAuthService
    {
        User User { get; set; }
        string Message { get; set; }
        event Action AuthStatus;
        Task Login(UserLogin request);
        Task<bool> Register(UserRegister request);
        Task AuthStatusInvoke();
    }
}
