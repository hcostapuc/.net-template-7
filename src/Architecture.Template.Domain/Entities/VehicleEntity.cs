using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Events;

namespace Domain.Entities;
public sealed class VehicleEntity: BaseAuditableEntity
{
    public required string Model { get; set; }
    public required Colour Colour { get; set; }
    public required string Manufacturer { get; set; }
}
