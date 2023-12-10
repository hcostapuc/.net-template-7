namespace Application.Client.Commands.UpdateClient;
public sealed record UpdateClientCommand(Guid Id,
                                         string Name,
                                         int PhoneNumber,
                                         string Address) : IRequest;