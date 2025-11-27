using MediatR;
using Vorlagen.Application.Features.TodoItems.Dtos;

namespace Vorlagen.Application.Features.TodoItems.Commands;

public class CreateTodoItemCommand : IRequest<TodoItemDto>
{
    public string Title { get; set; } = "";
}
