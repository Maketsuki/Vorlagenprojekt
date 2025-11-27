using MediatR;
using Vorlagen.Application.Contracts.Persistence;
using Vorlagen.Application.Features.TodoItems.Mappers;
using Vorlagen.Domain.Entities;
using Vorlagen.Shared.Features.TodoItems.Commands;
using Vorlagen.Shared.Features.TodoItems.Dtos;

namespace Vorlagen.Application.Features.TodoItems.Commands;

public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, TodoItemDto>
{
    private readonly ITodoItemRepository _todoItemRepository;

    public CreateTodoItemCommandHandler(ITodoItemRepository todoItemRepository)
    {
        _todoItemRepository = todoItemRepository;
    }

    public async Task<TodoItemDto> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var todoItem = new TodoItem
        {
            Title = request.Title
        };

        await _todoItemRepository.AddAsync(todoItem);

        return TodoItemMapper.ToDto(todoItem);
    }
}
