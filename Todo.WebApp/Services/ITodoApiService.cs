using Todo.Api.Models;

namespace Todo.WebApp.Services
{
    public interface ITodoApiService
    {
        Task<TodoItemModel?> CreateTodoItemAsync(CreateTodoItemModel model);
        Task<TodoItemModel?> EditTodoItemAsync(int id, EditTodoItemModel model);
        Task<TodoItemModel?> GetTodoItemAsync(int id);
        Task<List<TodoItemModel>?> GetTodosAsync();
    }
}