using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vorlagen.Application.Features.TodoItems.Commands;
using Vorlagen.Application.Features.TodoItems.Queries;

namespace Vorlagen.Api.Controllers;

[ApiController]
[Route("api/todo-items")]
public class TodoItemsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TodoItemsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var dtos = await _mediator.Send(new GetAllTodoItemsQuery());
        return Ok(dtos);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTodoItemCommand command)
    {
        var dto = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetAll), new { id = dto.Id }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTodoItemCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteTodoItemCommand { Id = id });
        return NoContent();
    }
}
