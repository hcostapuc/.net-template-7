namespace Application.Client.Queries.GetClient;
public sealed record GetClientRootDto(Guid Id,
                                       string Name,
                                       string Email,
                                       string Address);