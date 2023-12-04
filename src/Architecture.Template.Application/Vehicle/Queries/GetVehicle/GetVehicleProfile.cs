namespace Application.Vehicle.Queries.GetVehicle;
public class GetVehicleProfile : Profile
{
    public GetVehicleProfile() =>
        CreateMap<VehicleEntity, GetVehicleRootDto>().ReverseMap();
}
