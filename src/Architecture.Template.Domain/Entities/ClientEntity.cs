namespace Domain.Entities;
public sealed class ClientEntity : BaseAuditableEntity
{
    public required string Name { get; set; }
    //TODO: voltar com o mailAddress
    //public required MailAddress Email { get; set; }
    public required string Email { get; set; }
    public required string Address { get; set; }
    public IList<VehicleEntity> VehicleCollection { get; init; } = new List<VehicleEntity>();
    public IList<WashOrderEntity> WashOrderCollection { get; init; } = new List<WashOrderEntity>();
}