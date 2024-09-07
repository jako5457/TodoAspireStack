using System.Runtime.CompilerServices;
using Todo.Api.Data.Entities;
using Todo.Api.Models;

namespace Todo.Api.Mappers
{
    public static class TodoMappers
    {

        public static TodoItemModel ToModel(this TodoItem Item)
        {
            var (TodoItemId,Name,IsCompleted,CreatedDate) = Item;

            return new TodoItemModel()
            {
                CreatedDate = CreatedDate,
                IsCompleted = IsCompleted,
                Name = Name,
                TodoItemId = TodoItemId,
            };
        }

        public static TodoItem ToEntity(this TodoItemModel Model)
        {

            var (TodoItemId, Name, IsCompleted, CreatedDate) = Model;

            return new TodoItem()
            {
                CreatedDate = CreatedDate,
                IsCompleted = IsCompleted,
                Name = Name,
                TodoItemId = TodoItemId,
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
