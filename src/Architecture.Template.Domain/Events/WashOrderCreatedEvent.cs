using Ardalis.GuardClauses;

namespace Domain.Events;
public sealed class WashOrderCreatedEvent : BaseEvent
{
    public WashOrderEntity WashOrderEntity { get; }
    public WashOrderCreatedEvent(WashOrderEntity washOrderEntity) =>
        WashOrderEntity = washOrderEntity ?? Guard.Against.Null(washOrderEntity, nameof(washOrderEntity));
}