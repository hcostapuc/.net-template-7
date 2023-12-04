using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.Repository;
using Microsoft.Extensions.Logging;

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
        _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        _washOrderRepository = washOrderRepository ?? throw new ArgumentNullException(nameof(washOrderRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<Guid> Handle(CreateWashOrderCommand request, CancellationToken cancellationToken)
    {
        var clientEntity = await _clientRepository.SelectDetailAsync(x => x.Id == request.ClientId, cancellationToken);

        Guard.Against.NotFound(request.ClientId, clientEntity, nameof(clientEntity.Id));

        var vehicleToWash = clientEntity.VehicleCollection.FirstOrDefault(x => x.Id == request.VehicleId);

        Guard.Against.NotFound(request.VehicleId, clientEntity, nameof(clientEntity.VehicleCollection));

        var washOrderEntity = _mapper.Map<CreateWashOrderCommand,WashOrderEntity>(request);

        await _washOrderRepository.InsertAsync(washOrderEntity, cancellationToken);

        return washOrderEntity.Id;
    }
}