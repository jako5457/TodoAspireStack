namespace Todo.Api.Data.Entities
{
    public class TodoItem
    {

        public int TodoItemId { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now.ToUniversalTime();

        public bool IsCompleted { get; set; } = false;

    }
}
