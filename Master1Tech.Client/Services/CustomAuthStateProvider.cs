using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Master1Tech.Client.Services
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private bool _isLoggedIn = false;

        public void SetLoginStatus(bool loggedIn)
        {
            _isLoggedIn = loggedIn;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            ClaimsIdentity identity;

            if (_isLoggedIn)
            {
                identity = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, "Admin User"),
                new Claim(ClaimTypes.Role, "Admin")
            }, "FakeAuth");
            }
            else
            {
                identity = new ClaimsIdentity(); // No user
            }

            var user = new ClaimsPrincipal(identity);
            return Task.FromResult(new AuthenticationState(user));
        }

    }
}
