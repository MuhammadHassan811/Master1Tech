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

        public void MarkUserAsAuthenticated(ClaimsPrincipal user)
        {
            var authenticatedUser = new ClaimsPrincipal(user);
            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
            NotifyAuthenticationStateChanged(authState);
        }

        public void MarkUserAsLoggedOut()
        {
            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(anonymousUser));
            NotifyAuthenticationStateChanged(authState);
        }

    }
}
