using MediatR;
using Vorlagen.Application.Contracts.Persistence;
using Vorlagen.Application.Features.TodoItems.Mappers;
using Vorlagen.Shared.Features.TodoItems.Dtos;

namespace Vorlagen.Application.Features.TodoItems.Queries;

public class GetAllTodoItemsQueryHandler : IRequestHandler<GetAllTodoItemsQuery, IReadOnlyList<TodoItemDto>>
{
    private readonly ITodoItemRepository _todoItemRepository;

    public GetAllTodoItemsQueryHandler(ITodoItemRepository todoItemRepository)
    {
        _todoItemRepository = todoItemRepository;
    }

    public async Task<IReadOnlyList<TodoItemDto>> Handle(GetAllTodoItemsQuery request, CancellationToken cancellationToken)
    {
        var todoItems = await _todoItemRepository.GetAllAsync();
        return TodoItemMapper.ToDto(todoItems);
    }
}
