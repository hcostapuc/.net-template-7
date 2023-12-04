using Application.Vehicle.Commands.UpdateVehicle;
using Domain.Interfaces.Repository;

namespace Application.Vehicle.Commands.DeleteVehicle;
public sealed class UpdateVehicleCommandValidator : AbstractValidator<UpdateVehicleCommand>
{
    public UpdateVehicleCommandValidator()
    {
        RuleFor(v => v.Plate)
            .NotEmpty().WithMessage("Plate is required.");

        RuleFor(v => v.Model)
            .NotEmpty().WithMessage("Model is required.");

        RuleFor(v => v.Colour)
            .NotEmpty().WithMessage("Colour is required.");

        RuleFor(v => v.Manufacturer)
            .NotEmpty().WithMessage("Manufacturer is required.");
    }
}