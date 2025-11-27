namespace Vorlagen.Shared.Features.TodoItems.Dtos;

public class TodoItemDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = "";
    public bool IsDone { get; set; }
}
