using Application.Vehicle.Queries.GetVehicle;

namespace Application.Vehicle.Commands.DeleteVehicle;
public sealed class GetVehicleQueryValidator : AbstractValidator<GetVehicleQuery>
{
    public GetVehicleQueryValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Id is required.");
    }
}