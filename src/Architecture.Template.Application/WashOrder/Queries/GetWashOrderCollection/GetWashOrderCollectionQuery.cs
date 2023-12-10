using Application.WashOrder.Queries.GetWashOrder;

namespace Application.WashOrder.Queries.GetWashOrderCollection;
public sealed record GetWashOrderCollectionQuery() : IRequest<IList<GetWashOrderRootDto>>;