using Domain.Interfaces.Repository;

namespace Application.Client.Queries.GetClientDetail;
public sealed class GetClientDetailQueryHandler : IRequestHandler<GetClientDetailQuery, GetClientDetailRootDto>
{
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;
    public GetClientDetailQueryHandler(IClientRepository clientRepository,
                                       IMapper mapper)
    {
        _clientRepository = clientRepository ?? Guard.Against.Null(clientRepository, nameof(clientRepository));
        _mapper = mapper ?? Guard.Against.Null(mapper, nameof(mapper));

    }
    public async Task<GetClientDetailRootDto> Handle(GetClientDetailQuery request, CancellationToken cancellationToken)
    {
        var clientEntity = await _clientRepository.SelectDetailAsync(x => x.Id == request.Id, cancellationToken);
        Guard.Against.NotFound(request.Id, clientEntity, nameof(clientEntity.Id));
        return _mapper.Map<ClientEntity, GetClientDetailRootDto>(clientEntity);
    }
}