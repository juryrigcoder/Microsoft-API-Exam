namespace todoApi;

public record TodoModel
{
public int Id { get; set; }
public string Title { get; set; } = string.Empty; // Set a default value
public bool Completed { get; set; }
}
