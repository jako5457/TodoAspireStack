using System.Runtime.CompilerServices;
using Todo.Api.Data.Entities;
using Todo.Api.Models;

namespace Todo.Api.Mappers
{
    public static class TodoMappers
    {

        public static TodoItemModel ToModel(this TodoItem Item)
        {
            return new TodoItemModel()
            {
                CreatedDate = Item.CreatedDate,
                IsCompleted = Item.IsCompleted,
                Name = Item.Name,
                TodoItemId = Item.TodoItemId,
            };
        }

        public static TodoItem ToEntity(this TodoItemModel Model)
        {
            return new TodoItem()
            {
                CreatedDate = Model.CreatedDate,
                IsCompleted = Model.IsCompleted,
                Name = Model.Name,
                TodoItemId = Model.TodoItemId,
            };
        }
        public static TodoItem ToEntity(this CreateTodoItemModel Model)
        {
            return new TodoItem()
            {
                Name = Model.Name
            };
        }
        public static TodoItem ToEntity(this EditTodoItemModel Model)
        {
            return new TodoItem()
            {
                Name = Model.Name,
                IsCompleted = Model.IsCompleted
            };
        }

    }
}
