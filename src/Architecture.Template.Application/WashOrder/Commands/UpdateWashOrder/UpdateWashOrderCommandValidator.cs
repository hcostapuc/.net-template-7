using Application.WashOrder.Commands.UpdateWashOrder;

namespace Application.WashOrder.Commands.DeleteWashOrder;
public sealed class UpdateWashOrderCommandValidator : AbstractValidator<UpdateWashOrderCommand>
{
    public UpdateWashOrderCommandValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Id is required.");
    }
}