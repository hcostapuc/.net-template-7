using Domain.Interfaces.Repository;

namespace Application.TodoList.Commands.PurgeTodoList;

public class PurgeTodoListCommandHandler : IRequestHandler<PurgeTodoListCommand>
{
    private readonly ITodoListRepository _todoListRepository;

    public PurgeTodoListCommandHandler(ITodoListRepository todoListRepository) =>
        _todoListRepository = todoListRepository ?? throw new ArgumentNullException(nameof(todoListRepository));

    public async Task Handle(PurgeTodoListCommand request, CancellationToken cancellationToken) =>
        await _todoListRepository.PurgeAsync(cancellationToken);
}