using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Text.Json;
using Todo.WebApp.Models.Login;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Todo.WebApp.Services
{
    public class LoginService : ILoginService
    {
        private const string SessionName = nameof(LoginService);

        private readonly HttpClient _HttpClient;
        private readonly ILogger _Logger;
        private readonly ProtectedSessionStorage _ProtectedSessionStore;
        private LoginInformation? _LoginInformation = null!;

        public LoginService(HttpClient httpClient, ILogger<LoginService> logger, ProtectedSessionStorage ProtectedSessionStore)
        {
            _HttpClient = httpClient;
            _Logger = logger;
            _ProtectedSessionStore = ProtectedSessionStore;
        }

        public async Task RegisterAsync(RegisterModel model)
        {
            var result = await _HttpClient.PostAsJsonAsync("/register", model);

            result.EnsureSuccessStatusCode();
        }

        public async Task LoginAsync(LoginModel model)
        {
            var result = await _HttpClient.PostAsJsonAsync("/login", model);

            result.EnsureSuccessStatusCode();

            _LoginInformation = await result.Content.ReadFromJsonAsync<LoginInformation>();
            await CommitToSessionAsync();
        }

        public async Task RefreshTokenAsync()
        {
            if (_LoginInformation != null)
            {
                RefreshModel refreshModel = new RefreshModel() { refreshToken = _LoginInformation.refreshToken };

                var result = await _HttpClient.PostAsJsonAsync("/refresh", refreshModel);

                result.EnsureSuccessStatusCode();

                _LoginInformation = await result.Content.ReadFromJsonAsync<LoginInformation>();
                await CommitToSessionAsync();
            }
        }

        public async Task<string> GetAccessTokenAsync()
        {
            await LoadFromSessionAsync();
            if (_LoginInformation == null)
            {
                throw new ArgumentNullException("User must be logged in to get a access token");
            }

            if (_LoginInformation.TokenHasExpired())
            {
                await RefreshTokenAsync();
            }

            return _LoginInformation.accessToken;
        }

        private async Task CommitToSessionAsync()
        {
            if (_LoginInformation != null)
            {
                await _ProtectedSessionStore.SetAsync(SessionName, _LoginInformation);
            }
        }

        private async Task LoadFromSessionAsync()
        {
            var result = await _ProtectedSessionStore.GetAsync<LoginInformation>(SessionName);

            _LoginInformation = result.Value;
        }
    }
}
