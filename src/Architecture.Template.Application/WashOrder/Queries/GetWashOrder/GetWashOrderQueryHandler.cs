using Domain.Interfaces.Repository;

namespace Application.WashOrder.Queries.GetWashOrder;
public sealed class GetWashOrderQueryHandler : IRequestHandler<GetWashOrderQuery, GetWashOrderRootDto>
{
    private readonly IWashOrderRepository _washOrderRepository;
    private readonly IMapper _mapper;
    public GetWashOrderQueryHandler(IWashOrderRepository washOrderRepository,
                                    IMapper mapper)
    {
        _washOrderRepository = washOrderRepository ?? Guard.Against.Null(washOrderRepository, nameof(washOrderRepository));
        _mapper = mapper ?? Guard.Against.Null(mapper, nameof(mapper));

    }
    public async Task<GetWashOrderRootDto> Handle(GetWashOrderQuery request, CancellationToken cancellationToken)
    {
        var washOrderEntity = await _washOrderRepository.SelectAsync(x => x.Id == request.Id, cancellationToken);
        Guard.Against.NotFound(request.Id, washOrderEntity, nameof(washOrderEntity.Id));
        return _mapper.Map<WashOrderEntity, GetWashOrderRootDto>(washOrderEntity);
    }
}