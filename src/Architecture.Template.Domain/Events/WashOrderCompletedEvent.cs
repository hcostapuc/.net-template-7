namespace Domain.Events;
public sealed class WashOrderCompletedEvent : BaseEvent
{
    public WashOrderEntity WashOrderEntity { get; }
    public WashOrderCompletedEvent(WashOrderEntity washOrderEntity) =>
        WashOrderEntity = washOrderEntity ?? throw new ArgumentNullException(nameof(washOrderEntity));
}
