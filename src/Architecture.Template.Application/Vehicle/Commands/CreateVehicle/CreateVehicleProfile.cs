namespace Application.Vehicle.Commands.CreateVehicle;
public sealed class CreateVehicleProfile : Profile
{
    public CreateVehicleProfile() =>
        CreateMap<VehicleEntity, CreateVehicleCommand>()
            .ReverseMap();
}
