using System.Net.Http.Headers;
using Todo.Api.Models;

namespace Todo.WebApp.Services
{
    public class TodoApiService : ITodoApiService
    {
        private readonly HttpClient _HttpClient;
        private readonly ILoginService _LoginService;

        public TodoApiService(HttpClient client,ILoginService loginService)
        {
            _HttpClient = client;
            _LoginService = loginService;
        }

        public async Task<List<TodoItemModel>?> GetTodosAsync()
        {
            string token = await _LoginService.GetAccessTokenAsync();
            _HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);

            return await _HttpClient.GetFromJsonAsync<List<TodoItemModel>>("/api/todos");
        }

        public async Task<TodoItemModel?> GetTodoItemAsync(int id)
        {
            string token = await _LoginService.GetAccessTokenAsync();
            _HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await _HttpClient.GetFromJsonAsync<TodoItemModel>($"/api/todos/{id}");
        }

        public async Task<TodoItemModel?> CreateTodoItemAsync(CreateTodoItemModel model)
        {
            string token = await _LoginService.GetAccessTokenAsync();
            _HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _HttpClient.PostAsJsonAsync("/api/todos", model);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<TodoItemModel>();
        }

        public async Task<TodoItemModel?> EditTodoItemAsync(int id, EditTodoItemModel model)
        {
            string token = await _LoginService.GetAccessTokenAsync();
            _HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _HttpClient.PutAsJsonAsync($"/api/todos/{id}", model);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<TodoItemModel>();
        }
    }
}
