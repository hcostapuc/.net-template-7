namespace Application.WashOrder.Queries.GetWashOrder;
public sealed class GetWashOrderProfile : Profile
{
    public GetWashOrderProfile() =>
        CreateMap<WashOrderEntity, GetWashOrderRootDto>().ReverseMap();
}