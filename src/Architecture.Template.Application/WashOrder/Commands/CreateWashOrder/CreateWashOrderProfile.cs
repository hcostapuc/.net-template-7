namespace Application.WashOrder.Commands.CreateWashOrder;
public sealed class CreateWashOrderProfile : Profile
{
    public CreateWashOrderProfile() =>
        CreateMap<WashOrderEntity, CreateWashOrderCommand>()
            //.ForCtorParam(nameof(CreateWashOrderCommand.Name), opt => opt.MapFrom(src => src.Name))
            //.ForCtorParam(nameof(CreateWashOrderCommand.Address), opt => opt.MapFrom(src => src.Address))
            //.ForCtorParam(nameof(CreateWashOrderCommand.Email), opt => opt.MapFrom(src => src.Email))
            .ReverseMap();
}
