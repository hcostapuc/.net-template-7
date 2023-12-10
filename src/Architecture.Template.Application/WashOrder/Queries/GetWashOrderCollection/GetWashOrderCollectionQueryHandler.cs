using Application.WashOrder.Queries.GetWashOrder;
using Domain.Interfaces.Repository;

namespace Application.WashOrder.Queries.GetWashOrderCollection;
public sealed class GetWashOrderCollectionQueryHandler : IRequestHandler<GetWashOrderCollectionQuery, IList<GetWashOrderRootDto>>
{
    private readonly IWashOrderRepository _washOrderRepository;
    private readonly IMapper _mapper;
    public GetWashOrderCollectionQueryHandler(IWashOrderRepository washOrderRepository,
                                           IMapper mapper)
    {
        _washOrderRepository = washOrderRepository ?? Guard.Against.Null(washOrderRepository, nameof(washOrderRepository));
        _mapper = mapper ?? Guard.Against.Null(mapper, nameof(mapper));
    }
    public async Task<IList<GetWashOrderRootDto>> Handle(GetWashOrderCollectionQuery request, CancellationToken cancellationToken)
    {
        var washOrderEntityCollection = await _washOrderRepository.SelectAllAsync(cancellationToken);
        return _mapper.Map<IList<GetWashOrderRootDto>>(washOrderEntityCollection);
    }
}