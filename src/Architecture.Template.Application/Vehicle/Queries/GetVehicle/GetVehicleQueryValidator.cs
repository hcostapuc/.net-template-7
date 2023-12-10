namespace Application.Vehicle.Queries.GetVehicle;
public sealed class GetVehicleQueryValidator : AbstractValidator<GetVehicleQuery>
{
    public GetVehicleQueryValidator()
    {
        RuleFor(x => x.Plate)
           .NotEmpty().WithMessage("Plate is required.");
    }
}