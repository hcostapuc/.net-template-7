using Application.TodoItem.Commands.CreateTodoItem;
using Application.TodoItem.Commands.DeleteTodoItem;
using Application.TodoItem.Commands.UpdateTodoItem;
using Application.TodoItem.Commands.UpdateTodoItemDetail;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;

namespace WebApi.Controllers;

//TODO: voltar quando fazer teste de autorização
//[Authorize]
public class TodoItemController : ApiControllerBase
{
    //[HttpGet]//TODO: criar o pagination com o IQueryble component
    //public async Task<ActionResult<PaginatedList<TodoItemBriefDto>>> GetTodoItemsWithPagination([FromQuery] GetTodoItemsWithPaginationQuery query)
    //{
    //    return await Mediator.Send(query);
    //}

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateTodoItemCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, UpdateTodoItemCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpPut("[action]")]
    public async Task<ActionResult> UpdateItemDetails(Guid id, UpdateTodoItemDetailCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await Mediator.Send(new DeleteTodoItemCommand(id));

        return NoContent();
    }
}
