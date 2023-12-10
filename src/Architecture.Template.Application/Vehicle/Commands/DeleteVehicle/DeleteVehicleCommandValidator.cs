namespace Application.Vehicle.Commands.DeleteVehicle;
public sealed class DeleteVehicleCommandValidator : AbstractValidator<DeleteVehicleCommand>
{
    public DeleteVehicleCommandValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Id is required.");
    }
}