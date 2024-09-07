using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace Todo.Api.Data.Entities
{
    public class TodoItem
    {

        public int TodoItemId { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now.ToUniversalTime();

        public bool IsCompleted { get; set; } = false;

        public void Deconstruct(out int TodoItemId, out string Name,out bool IsCompleted,out DateTime CreatedDate)
        {
            TodoItemId = this.TodoItemId;
            Name = this.Name;
            IsCompleted = this.IsCompleted;
            CreatedDate = this.CreatedDate;
        }
    }
}
