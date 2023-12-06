using Domain.Interfaces.Repository;

namespace Application.WashOrder.Commands.CreateWashOrder;
public sealed class CreateWashOrderCommandHandler : IRequestHandler<CreateWashOrderCommand, Guid>
{
    private readonly IClientRepository _clientRepository;
    private readonly IWashOrderRepository _washOrderRepository;
    private readonly IMapper _mapper;
    public CreateWashOrderCommandHandler(IClientRepository clientRepository,
                                         IWashOrderRepository washOrderRepository,
                                         IMapper mapper)
    {
        _clientRepository = clientRepository ?? Guard.Against.Null(clientRepository, nameof(clientRepository));
        _washOrderRepository = washOrderRepository ?? Guard.Against.Null(washOrderRepository, nameof(washOrderRepository));
        _mapper = mapper ?? Guard.Against.Null(mapper, nameof(mapper));
    }
    public async Task<Guid> Handle(CreateWashOrderCommand request, CancellationToken cancellationToken)
    {
        var clientEntity = await _clientRepository.SelectDetailAsync(x => x.Id == request.ClientId, cancellationToken);

        Guard.Against.NotFound(request.ClientId, clientEntity, nameof(clientEntity.Id));

        var vehicleToWash = clientEntity.VehicleCollection.FirstOrDefault(x => x.Id == request.VehicleId);

        Guard.Against.NotFound(request.VehicleId, clientEntity, nameof(clientEntity.VehicleCollection));

        var washOrderEntity = _mapper.Map<CreateWashOrderCommand, WashOrderEntity>(request);

        await _washOrderRepository.InsertAsync(washOrderEntity, cancellationToken);
        //TODO: send to message, use out of box
        return washOrderEntity.Id;
    }
}