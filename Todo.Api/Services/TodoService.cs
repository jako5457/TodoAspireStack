using Microsoft.EntityFrameworkCore;
using Todo.Api.Data;
using Todo.Api.Data.Entities;

namespace Todo.Api.Services
{
    public class TodoService : ITodoService
    {
        private readonly TodoDbContext _Context;
        private readonly ILogger<TodoService> _Logger;

        public TodoService(TodoDbContext context, ILogger<TodoService> logger)
        {
            _Context = context;
            _Logger = logger;
        }

        public async Task<List<TodoItem>> GetTodoItemsAsync()
        {
            return await _Context.TodoItems.ToListAsync();
        }

        public async Task<TodoItem?> GetTodoItemAsync(int TodoItemId)
        {
            var query = _Context.TodoItems.Where(ti => ti.TodoItemId == TodoItemId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<TodoItem> CreateTodoItemAsync(TodoItem item)
        {
            _Context.TodoItems.Add(item);

            try
            {
                await _Context.SaveChangesAsync();
                _Logger.LogDebug("Created item successfully.");
                return item;
            }
            catch (Exception e)
            {
                _Logger.LogError("Creation of a todo item has failed.");
                throw;
            }

        }

        public async Task<TodoItem?> SetTodoItemAsync(TodoItem todoItem)
        {
            var OldItem = await _Context.TodoItems.Where(ti => ti.TodoItemId == todoItem.TodoItemId).FirstOrDefaultAsync();

            if (OldItem == null)
            {
                _Logger.LogError($"TodoItem with Id {todoItem.TodoItemId} does not exist.");
                return null;
            }

            OldItem.Name = todoItem.Name;
            OldItem.IsCompleted = todoItem.IsCompleted;

            try
            {
                await _Context.SaveChangesAsync();
                _Logger.LogDebug($"Todo ItemId {OldItem.TodoItemId} has changed.");
                return OldItem;
            }
            catch (Exception e)
            {
                _Logger.LogError("Change of a todo item has failed.");
                throw;
            }

        }
    }
}
