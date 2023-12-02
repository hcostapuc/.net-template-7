using Application.Client.Queries.GetClient;

namespace Application.Client.Commands.DeleteClient;
internal class GetClientDetailQueryValidator : AbstractValidator<GetClientQuery>
{
    public GetClientDetailQueryValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Id is required.");
    }
}