namespace Application.WashOrder.Queries.GetWashOrder;
public sealed class GetWashOrderQueryValidator : AbstractValidator<GetWashOrderQuery>
{
    public GetWashOrderQueryValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Id is required.");
    }
}