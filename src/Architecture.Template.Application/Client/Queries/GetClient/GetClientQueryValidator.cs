namespace Application.Client.Queries.GetClient;
public sealed class GetClientQueryValidator : AbstractValidator<GetClientQuery>
{
    public GetClientQueryValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Id is required.");
    }
}