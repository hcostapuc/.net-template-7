using Domain.Events;
using Microsoft.Extensions.Logging;

namespace Application.WashOrder.EventHandlers;
public sealed class WashOrderCompletedEventHandler : INotificationHandler<WashOrderCompletedEvent>
{
    private readonly ILogger<WashOrderCompletedEventHandler> _logger;
    public WashOrderCompletedEventHandler(ILogger<WashOrderCompletedEventHandler> logger) =>
        _logger = logger ?? Guard.Against.Null(logger, nameof(logger));

    public Task Handle(WashOrderCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Example of a simple event driven flow. Domain Event: {DomainEvent}", notification.GetType().Name);
        //TODO:Connect here a sms service to inform the client that the vehicle is ready to pick them up
        return Task.CompletedTask;
    }
}