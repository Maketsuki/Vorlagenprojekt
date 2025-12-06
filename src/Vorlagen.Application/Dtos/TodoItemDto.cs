namespace Vorlagen.Application.Dtos;

public class TodoItemDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = "";
    public bool IsDone { get; set; }
}
