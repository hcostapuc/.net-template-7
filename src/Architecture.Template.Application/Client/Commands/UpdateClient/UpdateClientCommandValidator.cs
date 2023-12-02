using Application.Client.Commands.UpdateClient;

namespace Application.Client.Commands.DeleteClient;
internal class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>
{
    public UpdateClientCommandValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Id is required.");
    }
}