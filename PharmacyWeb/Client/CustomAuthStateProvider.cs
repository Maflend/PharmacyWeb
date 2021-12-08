using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using PharmacyWeb.Client.Services.AuthService;
using PharmacyWeb.Shared;
using System.Security.Claims;

namespace PharmacyWeb.Client
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly IAuthService _authService;

      
        public CustomAuthStateProvider(ILocalStorageService localStorage, IAuthService authService)
        {
            _localStorage = localStorage;
            _authService = authService;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var state = new AuthenticationState(new ClaimsPrincipal());
            string username = await _localStorage.GetItemAsync<string>("username");
            string userpassword = await _localStorage.GetItemAsync<string>("password");

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(userpassword))
            {
                UserLogin userLogin = new UserLogin() { Username = username, Password = userpassword };
                 await _authService.Login(userLogin);
                
                if (_authService.User != null)
                {
                    var identity = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Name,_authService.User.Login),
                    }, "My authentication type");
                    state = new AuthenticationState(new ClaimsPrincipal(identity));
                }
                else
                {
                    state = new AuthenticationState(new ClaimsPrincipal());
                    _localStorage.RemoveItemAsync("username");
                    _localStorage.RemoveItemAsync("password");
                }    
            }

            NotifyAuthenticationStateChanged(Task.FromResult(state));
            
            _authService.AuthStatusInvoke();
            return state;
        }



    }
}
