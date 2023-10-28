using Domain.Interfaces.Repository;

namespace Application.TodoItem.Commands.UpdateTodoItem;
public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand>
{
    private readonly ITodoItemRepository _todoItemRepository;

    public UpdateTodoItemCommandHandler(ITodoItemRepository todoItemRepository) =>
        _todoItemRepository = todoItemRepository ?? throw new ArgumentNullException(nameof(todoItemRepository));

    public async Task Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _todoItemRepository.SelectAsync(x => x.Id == request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, entity, nameof(entity.Id));

        entity.UpdateEntityFieldsFrom(request);

        await _todoItemRepository.UpdateAsync(entity, cancellationToken);
    }
}