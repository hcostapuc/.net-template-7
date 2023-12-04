using System;
using Domain.Interfaces.Repository;

namespace Application.WashOrder.Commands.CreateWashOrder;
public sealed class CreateWashOrderCommandValidator : AbstractValidator<CreateWashOrderCommand>
{
    public CreateWashOrderCommandValidator()
    {
        RuleFor(v => v.ClientId)
            .NotEmpty().WithMessage("ClientId is required.");

        RuleFor(v => v.VehicleId)
            .NotEmpty().WithMessage("VehicleId is required.");
    }
}
