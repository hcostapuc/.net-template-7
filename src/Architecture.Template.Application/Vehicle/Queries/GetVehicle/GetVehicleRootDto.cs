namespace Application.Vehicle.Queries.GetVehicle;
public sealed record GetVehicleRootDto(Guid Id,
                                       string Model,
                                       string Colour,
                                       string Plate,
                                       string Manufacturer);