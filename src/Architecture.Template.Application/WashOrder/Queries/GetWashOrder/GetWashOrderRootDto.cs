namespace Application.WashOrder.Queries.GetWashOrder;
public sealed record GetWashOrderRootDto(Guid Id,
                                         string Description,
                                         string WashType,
                                         string Price,
                                         string Status);