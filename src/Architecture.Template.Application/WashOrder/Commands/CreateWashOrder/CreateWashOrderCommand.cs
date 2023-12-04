namespace Application.WashOrder.Commands.CreateWashOrder;
public sealed record CreateWashOrderCommand(Guid ClientId,
                                            Guid VehicleId,
                                            string WashType,
                                            float Price,
                                            string? Description) : IRequest<Guid>;