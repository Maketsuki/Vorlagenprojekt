namespace Vorlagen.Application.Dtos;

public class UpdateTodoItemDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = "";
    public bool IsDone { get; set; }
}
