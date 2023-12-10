using Application._Common.Extensions;
using Domain.Enums;
using Domain.Events;
using Domain.Interfaces.Repository;
using FluentValidation.Results;

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

        Guard.Against.AgainstValidationExpression(x => x, washOrderEntity.Status != StatusOrder.Closed,
                                                        new ValidationFailure(nameof(request.Id), "The WashOrder is already closed."));
        washOrderEntity.Status = StatusOrder.Closed;

        washOrderEntity.AddDomainEvent(new WashOrderCompletedEvent(washOrderEntity));

        await _washOrderRepository.UpdateAsync(washOrderEntity, cancellationToken);
    }
}