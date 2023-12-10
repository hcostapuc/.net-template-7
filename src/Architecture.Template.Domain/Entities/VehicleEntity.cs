using Domain.ValueObjects;

namespace Domain.Entities;
public sealed class VehicleEntity : BaseAuditableEntity
{
    public Guid ClientId { get; set; }
    public ClientEntity Client { get; set; }
    public required string Model { get; set; }
    // TODO Add value object Plate
    public required string Plate { get; set; }
    public required Colour Colour { get; set; }
    public required string Manufacturer { get; set; }
}