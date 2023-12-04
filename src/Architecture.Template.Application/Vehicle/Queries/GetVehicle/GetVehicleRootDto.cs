using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Vehicle.Queries.GetVehicle;
public sealed record GetVehicleRootDto(Guid Id,
                                       Guid ClientId,
                                       string Model,
                                       string Colour,
                                       string Plate,
                                       string Manufacturer);