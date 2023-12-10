namespace Application.Client.Queries.GetClientDetail;
public sealed record GetClientDetailVehicleDto(Guid Id,
                                               string Model,
                                               string Colour,
                                               string Plate,
                                               string Manufacturer);