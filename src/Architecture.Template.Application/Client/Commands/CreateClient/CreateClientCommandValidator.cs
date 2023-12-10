using Domain.Interfaces.Repository;

namespace Application.Client.Commands.CreateClient;
public sealed class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
{
    private readonly IClientRepository _clientRepository;
    public CreateClientCommandValidator(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository ?? Guard.Against.Null(clientRepository, nameof(clientRepository));

        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Name is required.");

        RuleFor(v => v.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress()
            .MustAsync(BeUniqueEmailAsync).WithMessage("The specified client email already exists.");

        RuleFor(v => v.PhoneNumber)
            .NotEmpty().WithMessage("PhoneNumber is required.")
            .Must(x => x.ToString().Length == 9).WithMessage("Invalid phone number needs to be 9 numbers");
    }

    public async Task<bool> BeUniqueEmailAsync(string email, CancellationToken cancellationToken) =>
        !await _clientRepository.ExistAsync(l => l.Email.Equals(email), cancellationToken);
}
