namespace Application.Client.Queries.GetClient;
public sealed record GetClientQuery(Guid Id) : IRequest<GetClientRootDto>;