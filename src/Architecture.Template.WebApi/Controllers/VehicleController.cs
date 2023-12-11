using Application.Vehicle.Commands.CreateVehicle;
using Application.Vehicle.Commands.DeleteVehicle;
using Application.Vehicle.Commands.UpdateVehicle;
using Application.Vehicle.Queries.GetVehicle;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;

namespace WebApi.Controllers;

public class VehicleController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateAsync(CreateVehicleCommand command) =>
         await Sender.Send(command);

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        await Sender.Send(new DeleteVehicleCommand(id));

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAsync(Guid id, UpdateVehicleCommand command)
    {
        if (id != command.Id)
            return BadRequest("Ids must be equals");

        await Sender.Send(command);

        return NoContent();
    }

    [HttpGet("{plate}")]
    public async Task<ActionResult<GetVehicleRootDto>> GetAsync(string plate) =>
         await Sender.Send(new GetVehicleQuery(plate));

}