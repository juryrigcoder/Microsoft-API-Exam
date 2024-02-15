using FluentValidation;

namespace todoApi;

public class TodoFluentValidator : AbstractValidator<TodoModel>
{
    private readonly IEnumerable<TodoModel> _todos;

    public TodoFluentValidator(IEnumerable<TodoModel> todos)
    {
        _todos = todos;
        // Validate the Id field to ensure it is unique
        RuleFor(x => x.Id).Must(IsNameUnique).WithMessage("Id must be unique");
    }

    // Check if the title is unique among all todos, excluding the todo being updated (if any)
    public bool IsNameUnique(TodoModel todo, int id)
    {
        // Check if the number of todos is 0
        Console.WriteLine(_todos.Count());
        // Check if the title is unique among all todos, excluding the todo being updated (if any)
        return _todos.All(todo => todo.Id != id);
    }
}