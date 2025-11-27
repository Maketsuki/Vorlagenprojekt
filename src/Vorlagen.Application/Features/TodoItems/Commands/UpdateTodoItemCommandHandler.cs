using MediatR;
using Vorlagen.Application.Contracts.Persistence;

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
            // Or throw an exception
            return;
        }

        todoItem.Title = request.Title;
        todoItem.IsDone = request.IsDone;

        await _todoItemRepository.UpdateAsync(todoItem);
    }
}
