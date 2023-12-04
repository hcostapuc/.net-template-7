namespace Application.Vehicle.Queries.GetVehicle;
public sealed record GetVehicleRootDto(Guid Id,
                                       Guid ClientId,
                                       string Model,
                                       string Colour,
                                       string Plate,
                                       string Manufacturer);