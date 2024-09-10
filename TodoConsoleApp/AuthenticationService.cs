using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace TodoConsoleApp
{
    internal class AuthenticationService
    {
        private readonly string _BaseAddress;

        AccessTokenInfo? _TokenInfo = null!;

        public AuthenticationService(string baseAddress) 
        {
            _BaseAddress = baseAddress;
        }

        public async Task RegisterAsync(string Email, string Password)
        {
            var query = _BaseAddress.AppendPathSegment("register");

            var response = await query.PostJsonAsync(new LoginModel { email = Email, password = Password });
        }

        public async Task<AccessTokenInfo?> LoginAsync(string Email, string Password)
        {
            var query = _BaseAddress.AppendPathSegment("login");

            var response = await query.PostJsonAsync(new LoginModel { email = Email, password = Password });

            _TokenInfo = await response.ResponseMessage.Content.ReadFromJsonAsync<AccessTokenInfo>();

            return _TokenInfo;
        }
    }
}
