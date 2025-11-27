using MediatR;

namespace Vorlagen.Application.Features.TodoItems.Commands;

public class UpdateTodoItemCommand : IRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; } = "";
    public bool IsDone { get; set; }
}
