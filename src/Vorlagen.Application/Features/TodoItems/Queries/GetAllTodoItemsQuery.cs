using MediatR;
using Vorlagen.Application.Features.TodoItems.Dtos;

namespace Vorlagen.Application.Features.TodoItems.Queries;

public class GetAllTodoItemsQuery : IRequest<IReadOnlyList<TodoItemDto>>
{
}
