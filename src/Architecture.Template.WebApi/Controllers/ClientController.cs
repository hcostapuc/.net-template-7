using Application.Client.Commands.CreateClient;
using Application.Client.Commands.DeleteClient;
using Application.Client.Commands.UpdateClient;
using Application.Client.Queries.GetClient;
using Application.Client.Queries.GetClientCollection;
using Application.Client.Queries.GetClientDetail;
using Application.TodoList.Commands.UpdateTodoList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;

namespace WebApi.Controllers;

public class ClientController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateAsync(CreateClientCommand command) =>
         await Sender.Send(command);

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        await Sender.Send(new DeleteClientCommand(id));

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAsync(Guid id, UpdateClientCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Sender.Send(command);

        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetClientRootDto>> GetAsync(Guid id) =>
         await Sender.Send(new GetClientQuery(id));

    [HttpGet]//TODO: see why didnt acception actionResult
    public async Task<IList<GetClientRootDto>> GetCollectionAsync() =>
         await Sender.Send(new GetClientCollectionQuery());

    [HttpGet("{id}/details")]
    public async Task<ActionResult<GetClientDetailRootDto>> GetDetailAsync(Guid id) =>
         await Sender.Send(new GetClientDetailQuery(id));
}
