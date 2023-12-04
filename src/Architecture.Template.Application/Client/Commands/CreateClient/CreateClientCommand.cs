namespace Application.Client.Commands.CreateClient;
public sealed record CreateClientCommand(string Name,
                                         string Email,
                                         string Address) : IRequest<Guid>;