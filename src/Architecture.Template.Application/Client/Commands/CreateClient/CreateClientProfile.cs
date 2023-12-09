namespace Application.Client.Commands.CreateClient;
public sealed class CreateClientProfile : Profile
{
    public CreateClientProfile() =>
        CreateMap<ClientEntity, CreateClientCommand>()
            .ReverseMap();
}
