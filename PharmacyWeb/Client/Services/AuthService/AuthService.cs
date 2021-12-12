using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using PharmacyWeb.Shared;
using PharmacyWeb.Shared.Models;
using System.Net.Http.Json;

namespace PharmacyWeb.Client.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;
   

        public event Action AuthStatus;

        public User User { get; set; }
        public string Message { get; set; } = "";
        public AuthService(HttpClient http, ILocalStorageService localStorage)
        {
            _http = http;
            _localStorage = localStorage;
       
        }

        public async Task Login(UserLogin request)
        {
            var response = await _http.PostAsJsonAsync<UserLogin>("api/auth/login", request);
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
        }
        public async Task AuthStatusInvoke()
        {
            AuthStatus.Invoke();
        }
        public async Task<bool> Register(UserRegister request)
        {
            var response = await _http.PostAsJsonAsync<UserRegister>("api/auth/register",request);
            var userResponse = await response.Content.ReadFromJsonAsync<ServiceResponse<User>>();
            bool success;
            if (userResponse?.Success == true)
            {
                Message = "Регистрация успешна";
                success = true;
            }
            else
            {
                Message = userResponse.Message;
                success = false;
            }
            AuthStatus.Invoke();
            return success;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("username");
            await _localStorage.RemoveItemAsync("password");
          //  await _authStateProvider.GetAuthenticationStateAsync();
            AuthStatus.Invoke();
        }
    }
}
