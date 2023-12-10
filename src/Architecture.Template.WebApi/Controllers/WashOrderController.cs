using Application.WashOrder.Commands.ConcludeWashOrder;
using Application.WashOrder.Commands.CreateWashOrder;
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

    [HttpPut("{id}/conclude")]
    public async Task<ActionResult> ConcludeAsync(Guid id)
    {
        await Sender.Send(new ConcludeWashOrderCommand(id));

        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetWashOrderRootDto>> GetAsync(Guid id) =>
         await Sender.Send(new GetWashOrderQuery(id));

    [HttpGet]
    public async Task<IList<GetWashOrderRootDto>> GetCollectionAsync() =>
         await Sender.Send(new GetWashOrderCollectionQuery());
}
