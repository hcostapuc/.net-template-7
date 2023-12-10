namespace Application.Vehicle.Commands.CreateVehicle;
/// <summary>
/// 
/// </summary>
/// <param name="ClientId"></param>
/// <param name="Model"></param>
/// <param name="Colour">Colour must be a hexadecial like #FFFFFF</param>
/// <param name="Plate"></param>
/// <param name="Manufacturer"></param>
public sealed record CreateVehicleCommand(Guid ClientId,
                                          string Model,
                                          string Colour,
                                          string Plate,
                                          string Manufacturer) : IRequest<Guid>;