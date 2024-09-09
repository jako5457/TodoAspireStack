using Todo.WebApp.Models.Login;

namespace Todo.WebApp.Services
{
    public interface ILoginService
    {
        Task<string> GetAccessTokenAsync();
        Task LoginAsync(LoginModel model);
        Task RefreshTokenAsync();
        Task RegisterAsync(RegisterModel model);
    }
}