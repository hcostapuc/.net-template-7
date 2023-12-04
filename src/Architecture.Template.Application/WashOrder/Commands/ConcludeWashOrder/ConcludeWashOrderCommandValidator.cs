namespace Application.WashOrder.Commands.DeleteWashOrder;
public sealed class ConcludeWashOrderCommandValidator : AbstractValidator<ConcludeWashOrderCommand>
{
    public ConcludeWashOrderCommandValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Id is required.");
    }
}