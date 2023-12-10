using Ardalis.GuardClauses;

namespace Domain.Events;
public sealed class WashOrderCompletedEvent : BaseEvent
{
    public WashOrderEntity WashOrderEntity { get; }
    public WashOrderCompletedEvent(WashOrderEntity washOrderEntity) =>
        WashOrderEntity = washOrderEntity ?? Guard.Against.Null(washOrderEntity, nameof(washOrderEntity));
}