﻿namespace Todo.Api.Models
{
    public class EditTodoItemModel
    {
        public string Name { get; set; } = string.Empty;

        public bool IsCompleted { get; set; } = false;
    }
}
