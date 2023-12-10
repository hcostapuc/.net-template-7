namespace Application.Client.Queries.GetClientDetail;
public sealed class GetClientDetailQueryValidator : AbstractValidator<GetClientDetailQuery>
{
    public GetClientDetailQueryValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Id is required.");
    }
}