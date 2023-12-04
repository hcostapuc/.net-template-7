namespace Application.Client.Queries.GetClientDetail;
public sealed record GetClientDetailVehicleDto(string Model,
                                               string Colour,
                                               string Plate,
                                               string Manufacturer);