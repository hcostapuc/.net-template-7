using Application.WashOrder.Queries.GetWashOrder;

namespace Application.WashOrder.Commands.DeleteWashOrder;
public sealed class GetWashOrderQueryValidator : AbstractValidator<GetWashOrderQuery>
{
    public GetWashOrderQueryValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Id is required.");
    }
}