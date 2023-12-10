namespace Application.WashOrder.Queries.GetWashOrder;
public sealed record GetWashOrderQuery(Guid Id) : IRequest<GetWashOrderRootDto>;