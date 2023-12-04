namespace Domain.Entities;
public sealed class VehicleEntity : BaseAuditableEntity
{
    public Guid ClientId { get; set; }
    public ClientEntity Client { get; set; }
    public required string Model { get; set; }
    //public Plate Plate { get; set; }// TODO change to valueobject
    public required string Plate { get; set; }
    //public required Colour Colour { get; set; }
    //TODO change to valueobject
    public required string Colour { get; set; }
    public required string Manufacturer { get; set; }
}