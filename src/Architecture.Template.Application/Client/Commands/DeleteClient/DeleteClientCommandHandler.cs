using Domain.Interfaces.Repository;

namespace Application.Client.Commands.DeleteClient;
public sealed class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand>
{
    private readonly IClientRepository _clientRepository;
    public DeleteClientCommandHandler(IClientRepository clientRepository) =>
        _clientRepository = clientRepository ?? Guard.Against.Null(clientRepository, nameof(clientRepository));
    public async Task Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        var clientEntity = await _clientRepository.SelectAsync(x => x.Id == request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, clientEntity, nameof(clientEntity.Id));

        await _clientRepository.DeleteAsync(clientEntity, cancellationToken);
    }
}