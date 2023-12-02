using Application.Client.Queries.GetClient;

namespace Application.Client.Commands.DeleteClient;
internal class GetClientQueryValidator : AbstractValidator<GetClientQuery>
{
    public GetClientQueryValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Id is required.");
    }
}