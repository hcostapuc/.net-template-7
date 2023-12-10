namespace Application.Vehicle.Commands.DeleteVehicle;
public sealed record DeleteVehicleCommand(Guid Id) : IRequest;