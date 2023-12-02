using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public sealed class ClientEntity: BaseAuditableEntity
{
    public required string Name { get; set; }
    public required Email Email { get; set; }
    public required string Address { get; set; }
    public IList<VehicleEntity> VehicleCollection { get; private set; } = new List<VehicleEntity>();
}