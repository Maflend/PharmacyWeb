using Blazored.LocalStorage;
using PharmacyWeb.Shared;
using PharmacyWeb.Shared.Models;
using System.Net.Http.Json;

namespace PharmacyWeb.Client.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;

        public event Action AuthStatus;

        public User User { get; set; }
        public string Message { get; set; } = "";
        public AuthService(HttpClient http)
        {
           
            _http = http;
        }

        public async Task Login(UserLogin request)
        {
            var response = await _http.PostAsJsonAsync<UserLogin>($"api/auth/login", request);
            var userResponse = await response.Content.ReadFromJsonAsync<ServiceResponse<User>>();
            
            if(userResponse.Success)
            {
                User = userResponse.Data;
                Message = "";
            }
            else
            {
                User = null;
                Message = userResponse.Message;
            }
            AuthStatus.Invoke();
            
        }
    }
}
