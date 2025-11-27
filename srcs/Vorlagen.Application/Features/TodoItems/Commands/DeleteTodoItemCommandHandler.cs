using MediatR;
using Vorlagen.Application.Contracts.Persistence;

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
            // Or throw an exception
            return;
        }

        await _todoItemRepository.DeleteAsync(todoItem);
    }
}
