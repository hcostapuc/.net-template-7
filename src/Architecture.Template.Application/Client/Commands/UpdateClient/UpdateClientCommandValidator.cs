namespace Application.Client.Commands.UpdateClient;
public sealed class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>
{
    public UpdateClientCommandValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Id is required.");
    }
}