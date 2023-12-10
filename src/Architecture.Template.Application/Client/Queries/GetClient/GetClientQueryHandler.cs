using Domain.Interfaces.Repository;

namespace Application.Client.Queries.GetClient;
public sealed class GetClientQueryHandler : IRequestHandler<GetClientQuery, GetClientRootDto>
{
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;
    public GetClientQueryHandler(IClientRepository clientRepository,
                                 IMapper mapper)
    {
        _clientRepository = clientRepository ?? Guard.Against.Null(clientRepository, nameof(clientRepository));
        _mapper = mapper ?? Guard.Against.Null(mapper, nameof(mapper));

    }
    public async Task<GetClientRootDto> Handle(GetClientQuery request, CancellationToken cancellationToken)
    {
        var clientEntity = await _clientRepository.SelectAsync(x => x.Id == request.Id, cancellationToken);
        Guard.Against.NotFound(request.Id, clientEntity, nameof(clientEntity.Id));
        return _mapper.Map<ClientEntity, GetClientRootDto>(clientEntity);
    }
}