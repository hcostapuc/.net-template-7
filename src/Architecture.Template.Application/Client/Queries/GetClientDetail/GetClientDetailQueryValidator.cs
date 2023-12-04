using Application.Client.Queries.GetClient;
using Application.Client.Queries.GetClientDetail;

namespace Application.Client.Commands.DeleteClient;
public sealed class GetClientDetailQueryValidator : AbstractValidator<GetClientDetailQuery>
{
    public GetClientDetailQueryValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Id is required.");
    }
}