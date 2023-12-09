using Domain.Enums;
using Domain.Interfaces.Repository;

namespace Application.WashOrder.Commands.ConcludeWashOrder;
public sealed class ConcludeWashOrderCommandHandler : IRequestHandler<ConcludeWashOrderCommand>
{
    private readonly IWashOrderRepository _washOrderRepository;
    public ConcludeWashOrderCommandHandler(IWashOrderRepository washOrderRepository) =>
        _washOrderRepository = washOrderRepository ?? Guard.Against.Null(washOrderRepository, nameof(washOrderRepository));
    public async Task Handle(ConcludeWashOrderCommand request, CancellationToken cancellationToken)
    {
        var washOrderEntity = await _washOrderRepository.SelectAsync(x => x.Id == request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, washOrderEntity, nameof(washOrderEntity.Id));

        washOrderEntity.Status = StatusOrder.Closed;

        //TODO: send sms to client use out of box
        await _washOrderRepository.UpdateAsync(washOrderEntity, cancellationToken);
    }
}