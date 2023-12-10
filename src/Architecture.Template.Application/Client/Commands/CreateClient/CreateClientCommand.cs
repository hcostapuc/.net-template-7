namespace Application.Client.Commands.CreateClient;
public sealed record CreateClientCommand(string Name,
                                         string Email,
                                         int PhoneNumber,
                                         string Address) : IRequest<Guid>;