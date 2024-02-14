namespace todoRazor;

public class Todo
{
    public class Content
    {
        public List<TodoItem> Items { get; set; }
    }

    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty; // Set a default value
        public bool Completed { get; set; }
    }
    record AddTodoItem(string? Title);
}