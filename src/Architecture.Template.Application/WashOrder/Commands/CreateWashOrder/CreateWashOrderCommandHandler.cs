using Domain.Events;
using Domain.Interfaces.Repository;

namespace Application.WashOrder.Commands.CreateWashOrder;
public sealed class CreateWashOrderCommandHandler : IRequestHandler<CreateWashOrderCommand, Guid>
{
    private readonly IWashOrderRepository _washOrderRepository;
    private readonly IMapper _mapper;
    public CreateWashOrderCommandHandler(IWashOrderRepository washOrderRepository,
                                         IMapper mapper)
    {
        _washOrderRepository = washOrderRepository ?? Guard.Against.Null(washOrderRepository, nameof(washOrderRepository));
        _mapper = mapper ?? Guard.Against.Null(mapper, nameof(mapper));
    }
    public async Task<Guid> Handle(CreateWashOrderCommand request, CancellationToken cancellationToken)
    {
        var washOrderEntity = _mapper.Map<CreateWashOrderCommand, WashOrderEntity>(request);

        //TODO: Add the washorder to a queue using transactional outbox pattern
        washOrderEntity.AddDomainEvent(new WashOrderCreatedEvent(washOrderEntity));

        await _washOrderRepository.InsertAsync(washOrderEntity, cancellationToken);

        return washOrderEntity.Id;
    }
}