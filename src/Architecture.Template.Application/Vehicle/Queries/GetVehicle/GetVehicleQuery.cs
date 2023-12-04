namespace Application.Vehicle.Queries.GetVehicle;
public sealed record GetVehicleQuery(Guid Id) : IRequest<GetVehicleRootDto>;