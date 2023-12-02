using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.TodoItem.Commands.CreateTodoItem;
using Domain.Interfaces.Repository;

namespace Application.Client.Commands.CreateClient;
public sealed class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
{
    private readonly IClientRepository _clientRepository;
    public CreateClientCommandValidator(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));

        RuleFor(v => v.Email)
            .NotEmpty().WithMessage("Title is required.")
            .EmailAddress()
            .MustAsync(BeUniqueEmail).WithMessage("The specified client email already exists.");
    }

    public async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken) =>
        !await _clientRepository.ExistAsync(l => l.Email.Equals(email), cancellationToken);
}
