using MediatR;
using Vorlagen.Application.Contracts.Persistence;
using Vorlagen.Application.Features.TodoItems.Commands;
using Vorlagen.Application.Features.TodoItems.Dtos;
using Vorlagen.Application.Features.TodoItems.Mappers;
using Vorlagen.Domain.Entities;

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
