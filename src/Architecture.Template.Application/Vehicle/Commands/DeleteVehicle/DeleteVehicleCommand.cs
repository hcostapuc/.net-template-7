using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Vehicle.Commands.DeleteVehicle;
public sealed record DeleteVehicleCommand(Guid Id): IRequest;