using MediatR;
using Vorlagen.Application.Contracts.Persistence;
using Vorlagen.Application.Exceptions;
using Vorlagen.Domain.Entities;
using Vorlagen.Application.Features.TodoItems.Commands;

namespace Vorlagen.Application.Features.TodoItems.Commands;

public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand>
{
    private readonly ITodoItemRepository _todoItemRepository;

    public UpdateTodoItemCommandHandler(ITodoItemRepository todoItemRepository)
    {
        _todoItemRepository = todoItemRepository;
    }

    public async Task Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var todoItem = await _todoItemRepository.GetByIdAsync(request.Id);

        if (todoItem is null)
        {
            throw new NotFoundException(nameof(TodoItem), request.Id);
        }

        todoItem.Title = request.Title;
        todoItem.IsDone = request.IsDone;

        await _todoItemRepository.UpdateAsync(todoItem);
    }
}
