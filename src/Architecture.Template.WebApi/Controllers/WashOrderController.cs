using Application.WashOrder.Commands.CreateWashOrder;
using Application.WashOrder.Commands.DeleteWashOrder;
using Application.WashOrder.Commands.UpdateWashOrder;
using Application.WashOrder.Queries.GetWashOrder;
using Application.WashOrder.Queries.GetWashOrderCollection;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;

namespace WebApi.Controllers;

public class WashOrderController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateAsync(CreateWashOrderCommand command) =>
         await Sender.Send(command);

    [HttpPost("{id}/conclude")]
    public async Task<ActionResult> ConcludeAsync(Guid id)
    {
        await Sender.Send(new ConcludeWashOrderCommand(id));

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAsync(Guid id, UpdateWashOrderCommand command)
    {
        if (id != command?.Id)
        {
            return BadRequest($"Incompatible id between body {command?.Id} and path {id}");
        }

        await Sender.Send(command);

        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetWashOrderRootDto>> GetAsync(Guid id) =>
         await Sender.Send(new GetWashOrderQuery(id));

    [HttpGet]//TODO: see why didnt acception actionResult
    public async Task<IList<GetWashOrderRootDto>> GetCollectionAsync() =>
         await Sender.Send(new GetWashOrderCollectionQuery());
}
