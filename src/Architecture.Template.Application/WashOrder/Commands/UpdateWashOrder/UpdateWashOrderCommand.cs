namespace Application.WashOrder.Commands.UpdateWashOrder;
public sealed record UpdateWashOrderCommand(Guid Id,
                                            string WashType,
                                            float Price,
                                            string? Description) : IRequest;