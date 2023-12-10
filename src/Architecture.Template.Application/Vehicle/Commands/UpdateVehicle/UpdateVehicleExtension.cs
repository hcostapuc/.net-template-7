using Domain.ValueObjects;

namespace Application.Vehicle.Commands.UpdateVehicle;
internal static class UpdateVehicleExtension
{
    internal static void UpdateEntityFieldsFrom(this VehicleEntity vehicleEntity, UpdateVehicleCommand updateVehicleCommand)
    {
        vehicleEntity.Manufacturer = updateVehicleCommand.Manufacturer;
        vehicleEntity.Model = updateVehicleCommand.Model;
        vehicleEntity.Colour = Colour.From(updateVehicleCommand.Colour);
    }
}