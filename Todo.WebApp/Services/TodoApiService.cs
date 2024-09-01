using Todo.Api.Models;

namespace Todo.WebApp.Services
{
    public class TodoApiService : ITodoApiService
    {
        private readonly HttpClient _HttpClient;

        public TodoApiService(HttpClient client)
        {
            _HttpClient = client;
        }

        public async Task<List<TodoItemModel>?> GetTodosAsync()
        {
            return await _HttpClient.GetFromJsonAsync<List<TodoItemModel>>("/api/todos");
        }

        public async Task<TodoItemModel?> GetTodoItemAsync(int id)
        {
            return await _HttpClient.GetFromJsonAsync<TodoItemModel>($"/api/todos/{id}");
        }

        public async Task<TodoItemModel?> CreateTodoItemAsync(CreateTodoItemModel model)
        {
            var response = await _HttpClient.PostAsJsonAsync("/api/todos", model);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<TodoItemModel>();
        }

        public async Task<TodoItemModel?> EditTodoItemAsync(int id, EditTodoItemModel model)
        {
            var response = await _HttpClient.PutAsJsonAsync($"/api/todos/{id}", model);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<TodoItemModel>();
        }
    }
}
