namespace Application.Client.Queries.GetClient;
public sealed class GetClientProfile : Profile
{
    public GetClientProfile() =>
        CreateMap<ClientEntity, GetClientRootDto>().ReverseMap();
}
