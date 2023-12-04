using Application.Client.Queries.GetClient;

namespace Application.Client.Queries.GetClientCollection;
public sealed record GetClientCollectionQuery() : IRequest<IList<GetClientRootDto>>;