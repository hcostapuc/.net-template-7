namespace Application.Client.Queries.GetClientDetail;
public sealed record GetClientDetailRootDto(Guid Id,
                                            string Name,
                                            string Email,
                                            string Address)
{
    public IList<GetClientDetailVehicleDto> VehicleCollection { get; init; } = new List<GetClientDetailVehicleDto>();

}