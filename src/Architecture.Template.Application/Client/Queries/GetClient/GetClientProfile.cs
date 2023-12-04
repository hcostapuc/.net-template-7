namespace Application.Client.Queries.GetClient;
public class GetClientProfile : Profile
{
    public GetClientProfile() =>
        CreateMap<ClientEntity, GetClientRootDto>().ReverseMap();
}
