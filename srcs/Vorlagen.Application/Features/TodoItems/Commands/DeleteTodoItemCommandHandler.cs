using MediatR;
using Vorlagen.Application.Contracts.Persistence;
using Vorlagen.Application.Exceptions;
using Vorlagen.Domain.Entities;
using Vorlagen.Shared.Features.TodoItems.Commands;

namespace Vorlagen.Application.Features.TodoItems.Commands;

public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand>
{
    private readonly ITodoItemRepository _todoItemRepository;

    public DeleteTodoItemCommandHandler(ITodoItemRepository todoItemRepository)
    {
        _todoItemRepository = todoItemRepository;
    }

    public async Task Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
    {
        var todoItem = await _todoItemRepository.GetByIdAsync(request.Id);

        if (todoItem is null)
        {
            throw new NotFoundException(nameof(TodoItem), request.Id);
        }

        await _todoItemRepository.DeleteAsync(todoItem);
    }
}
