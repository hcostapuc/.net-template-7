using Application.Client.Queries.GetClient;
using Domain.Interfaces.Repository;

namespace Application.Client.Queries.GetClientCollection;
public sealed class GetClientCollectionQueryHandler : IRequestHandler<GetClientCollectionQuery, IList<GetClientRootDto>>
{
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;
    public GetClientCollectionQueryHandler(IClientRepository clientRepository,
                                           IMapper mapper)
    {
        _clientRepository = clientRepository ?? Guard.Against.Null(clientRepository, nameof(clientRepository));
        _mapper = mapper ?? Guard.Against.Null(mapper, nameof(mapper));
    }
    public async Task<IList<GetClientRootDto>> Handle(GetClientCollectionQuery request, CancellationToken cancellationToken)
    {
        var clientEntityCollection = await _clientRepository.SelectAllAsync(cancellationToken);
        return _mapper.Map<IList<GetClientRootDto>>(clientEntityCollection);
    }
}