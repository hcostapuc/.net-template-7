namespace Application.Vehicle.Queries.GetVehicle;
public sealed record GetVehicleQuery(string Plate) : IRequest<GetVehicleRootDto>;