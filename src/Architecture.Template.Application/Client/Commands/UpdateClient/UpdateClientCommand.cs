namespace Application.Client.Commands.UpdateClient;
public sealed record UpdateClientCommand(Guid Id,
                                         string Name,
                                         string Address) : IRequest;