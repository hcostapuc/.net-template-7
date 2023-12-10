namespace Application.Client.Queries.GetClientDetail;
public sealed record GetClientDetailQuery(Guid Id) : IRequest<GetClientDetailRootDto>;