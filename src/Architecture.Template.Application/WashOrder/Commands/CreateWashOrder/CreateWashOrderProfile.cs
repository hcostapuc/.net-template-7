namespace Application.WashOrder.Commands.CreateWashOrder;
public sealed class CreateWashOrderProfile : Profile
{
    public CreateWashOrderProfile() =>
        CreateMap<WashOrderEntity, CreateWashOrderCommand>()
            .ReverseMap();
}
