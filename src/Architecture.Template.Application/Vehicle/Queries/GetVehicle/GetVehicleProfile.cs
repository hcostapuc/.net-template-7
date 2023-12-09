namespace Application.Vehicle.Queries.GetVehicle;
public sealed class GetVehicleProfile : Profile
{
    public GetVehicleProfile() =>
        CreateMap<VehicleEntity, GetVehicleRootDto>().ReverseMap();
}
