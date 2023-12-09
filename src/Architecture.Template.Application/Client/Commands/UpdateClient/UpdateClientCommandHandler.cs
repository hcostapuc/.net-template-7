using Domain.Interfaces.Repository;

namespace Application.Client.Commands.UpdateClient;
public sealed class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand>
{
    private readonly IClientRepository _clientRepository;
    public UpdateClientCommandHandler(IClientRepository clientRepository) =>
        _clientRepository = clientRepository ?? Guard.Against.Null(clientRepository, nameof(clientRepository));
    public async Task Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        var clientEntity = await _clientRepository.SelectAsync(x => x.Id == request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, clientEntity, nameof(clientEntity));

        clientEntity.UpdateEntityFieldsFrom(request);

        await _clientRepository.UpdateAsync(clientEntity, cancellationToken);
    }
}