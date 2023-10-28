using Domain.Interfaces.Repository;

namespace Application.TodoList.Commands.UpdateTodoList;

public class UpdateTodoListCommandHandler : IRequestHandler<UpdateTodoListCommand>
{
    private readonly ITodoListRepository _todoListRepository;

    public UpdateTodoListCommandHandler(ITodoListRepository todoListRepository) =>
        _todoListRepository = todoListRepository ?? throw new ArgumentNullException(nameof(todoListRepository));

    public async Task Handle(UpdateTodoListCommand request, CancellationToken cancellationToken)
    {
        var entity = await _todoListRepository.SelectAsync(x => x.Id == request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, entity, nameof(entity));
        entity.Title = request.Title;

        await _todoListRepository.UpdateAsync(entity, cancellationToken);
    }
}