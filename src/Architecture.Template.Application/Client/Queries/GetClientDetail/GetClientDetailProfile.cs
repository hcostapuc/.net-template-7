namespace Application.Client.Queries.GetClientDetail;
public sealed class GetClientDetailProfile : Profile
{
    public GetClientDetailProfile()
    {
        CreateMap<ClientEntity, GetClientDetailRootDto>().ReverseMap();
        CreateMap<VehicleEntity, GetClientDetailVehicleDto>().ReverseMap();

    }
}
