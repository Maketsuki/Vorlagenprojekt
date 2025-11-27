using MediatR;

namespace Vorlagen.Application.Features.TodoItems.Commands;

public class DeleteTodoItemCommand : IRequest
{
    public Guid Id { get; set; }
}
