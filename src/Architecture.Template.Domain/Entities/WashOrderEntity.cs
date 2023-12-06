using Domain.Events;

namespace Domain.Entities;
public sealed class WashOrderEntity : BaseAuditableEntity
{
    public required Guid ClientId { get; set; }
    public required ClientEntity Client { get; set; }
    public required Guid VehicleId { get; set; }
    public required VehicleEntity Vehicle { get; set; }
    //public required WashType WashType { get; set; } = WashType.Ordinary;//TODO voltar para enum
    public required string WashType { get; set; }
    public float Price { get; set; }
    public required StatusOrder Status { get; set; } = StatusOrder.Open;
    public string? Description { get; set; }

    private readonly bool _done;
    public bool Done
    {
        get => _done; set
        {

            if (value && !_done)
                AddDomainEvent(new WashOrderCompletedEvent(this));
        }
    }
}