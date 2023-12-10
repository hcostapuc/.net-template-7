using Domain.Events;
using Microsoft.Extensions.Logging;

namespace Application.WashOrder.EventHandlers;
public sealed class WashOrderCreatedEventHandler : INotificationHandler<WashOrderCreatedEvent>
{
    private readonly ILogger<WashOrderCreatedEventHandler> _logger;
    public WashOrderCreatedEventHandler(ILogger<WashOrderCreatedEventHandler> logger) =>
        _logger = logger ?? Guard.Against.Null(logger, nameof(logger));
    public Task Handle(WashOrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Example of a transactional outbox pattern event flow. Domain Event: {DomainEvent}", notification.GetType().Name);
        //TODO: Add the washorder to a queue using transactional outbox pattern
        return Task.CompletedTask;
    }
}
