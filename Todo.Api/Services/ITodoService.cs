using Todo.Api.Data.Entities;

namespace Todo.Api.Services
{
    public interface ITodoService
    {
        Task<TodoItem> CreateTodoItemAsync(TodoItem item);
        Task<TodoItem?> GetTodoItemAsync(int TodoItemId);
        Task<List<TodoItem>> GetTodoItemsAsync();
        Task<TodoItem?> SetTodoItemAsync(TodoItem todoItem);
    }
}