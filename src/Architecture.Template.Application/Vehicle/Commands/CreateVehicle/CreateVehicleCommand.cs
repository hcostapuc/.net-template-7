namespace Application.Vehicle.Commands.CreateVehicle;
public sealed record CreateVehicleCommand(Guid ClientId,
                                          string Model,
                                          string Colour,
                                          string Plate,
                                          string Manufacturer) : IRequest<Guid>;