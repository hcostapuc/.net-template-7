namespace Application.WashOrder.Commands.UpdateWashOrder;
public sealed class UpdateWashOrderCommandValidator : AbstractValidator<UpdateWashOrderCommand>
{
    public UpdateWashOrderCommandValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Id is required.");
    }
}