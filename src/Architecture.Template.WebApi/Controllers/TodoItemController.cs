using Application.TodoItem.Commands.CreateTodoItem;
using Application.TodoItem.Commands.DeleteTodoItem;
using Application.TodoItem.Commands.UpdateTodoItem;
using Application.TodoItem.Commands.UpdateTodoItemDetail;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;

namespace WebApi.Controllers;

public class TodoItemController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateAsync(CreateTodoItemCommand command) =>
         await Sender.Send(command);

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAsync(Guid id, UpdateTodoItemCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Sender.Send(command);

        return NoContent();
    }

    [HttpPut("[action]")]
    public async Task<ActionResult> UpdateItemDetailsAsync(Guid id, UpdateTodoItemDetailCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Sender.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        await Sender.Send(new DeleteTodoItemCommand(id));

        return NoContent();
    }
}
