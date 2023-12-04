using Domain.Interfaces.Repository;

namespace Application.WashOrder.Commands.DeleteWashOrder;
public sealed class ConcludeWashOrderCommandHandler : IRequestHandler<ConcludeWashOrderCommand>
{
    private readonly IWashOrderRepository _washOrderRepository;
    public ConcludeWashOrderCommandHandler(IWashOrderRepository washOrderRepository) =>
        _washOrderRepository = washOrderRepository ?? throw new ArgumentNullException(nameof(washOrderRepository));
    public async Task Handle(ConcludeWashOrderCommand request, CancellationToken cancellationToken)
    {
        var washOrderEntity = await _washOrderRepository.SelectAsync(x => x.Id == request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, washOrderEntity, nameof(washOrderEntity.Id));

        washOrderEntity.Status = StatusOrder.Closed;

        await _washOrderRepository.DeleteAsync(washOrderEntity, cancellationToken);
        //TODO: send sms to client
    }
}