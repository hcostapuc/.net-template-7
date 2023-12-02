using Domain.Interfaces.Repository;

namespace Application.TodoList.Commands.CreateTodoList;

public class CreateTodoListCommandValidator : AbstractValidator<CreateTodoListCommand>
{
    private readonly IVehicleRepository _todoListRepository;

    public CreateTodoListCommandValidator(IVehicleRepository todoListRepository)
    {
        _todoListRepository = todoListRepository ?? throw new ArgumentNullException(nameof(todoListRepository));

        RuleFor(v => v.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
            .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");
    }

    public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken) =>
        !await _todoListRepository.ExistAsync(l => l.Title == title, cancellationToken);
}