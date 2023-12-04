using Domain.Interfaces.Repository;

namespace Application.Client.Commands.CreateClient;
public sealed class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Guid>
{
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;
    public CreateClientCommandHandler(IClientRepository clientRepository,
                                      IMapper mapper)
    {
        _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<Guid> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var clientEntity = _mapper.Map<CreateClientCommand, ClientEntity>(request);

        await _clientRepository.InsertAsync(clientEntity, cancellationToken);

        return clientEntity.Id;
    }
}