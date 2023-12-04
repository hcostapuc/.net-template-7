using Domain.Interfaces.Repository;

namespace Application.WashOrder.Commands.UpdateWashOrder;
public sealed class UpdateWashOrderCommandHandler : IRequestHandler<UpdateWashOrderCommand>
{
    private readonly IWashOrderRepository _washOrderRepository;
    public UpdateWashOrderCommandHandler(IWashOrderRepository washOrderRepository) =>
        _washOrderRepository = washOrderRepository ?? throw new ArgumentNullException(nameof(washOrderRepository));
    public async Task Handle(UpdateWashOrderCommand request, CancellationToken cancellationToken)
    {
        var washOrderEntity = await _washOrderRepository.SelectAsync(x => x.Id == request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, washOrderEntity, nameof(washOrderEntity));

        washOrderEntity.UpdateEntityFieldsFrom(request);

        await _washOrderRepository.UpdateAsync(washOrderEntity, cancellationToken);
    }
}