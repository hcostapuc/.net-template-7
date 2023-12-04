using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Vehicle.Commands.UpdateVehicle;
internal static class UpdateVehicleExtension
{
    internal static void UpdateEntityFieldsFrom(this VehicleEntity vehicleEntity, UpdateVehicleCommand updateVehicleCommand)
    {
        vehicleEntity.Manufacturer = updateVehicleCommand.Manufacturer;
        vehicleEntity.Model = updateVehicleCommand.Model;
        vehicleEntity.Colour = updateVehicleCommand.Colour;
    }
}