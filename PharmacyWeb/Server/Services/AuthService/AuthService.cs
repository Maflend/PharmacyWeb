using Microsoft.EntityFrameworkCore;
using PharmacyWeb.Server.Data;
using PharmacyWeb.Shared;
using PharmacyWeb.Shared.Models;

namespace PharmacyWeb.Server.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;

        public AuthService(DataContext context)
        {
            _context = context;
        }
        public async Task<User> Login(UserLogin request)
        {
            var user = await _context.Users
                .Where(u => u.Login == request.Username && u.Password == request.Password)
                .FirstOrDefaultAsync();
            return user;
        }

        public async Task<User> Register(UserRegister request)
        {
            User user = null;
            if (!_context.Users.Any(u=>u.Login == request.Username))
            {
                user = new User();
                user.Login = request.Username;
                user.Password = request.Password;
                user.Role = Roles.Client;
                _context.Add(user);
                await _context.SaveChangesAsync();
            }
            return user;
        }
        public async Task<User> LoginGuest()
        {
            var user = new User() {Login = "Guest", Role = Roles.Guest };
            return user;
        }
    }
}
