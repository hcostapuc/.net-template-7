using Domain.Events;
using Domain.Interfaces.Repository;

namespace Application.TodoItem.Commands.DeleteTodoItem;
public sealed class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand>
{
    private readonly IClientRepository _todoItemRepository;

    public DeleteTodoItemCommandHandler(IClientRepository todoItemRepository) =>
        _todoItemRepository = todoItemRepository ?? throw new ArgumentNullException(nameof(todoItemRepository));

    public async Task Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _todoItemRepository.SelectAsync(x => x.Id == request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, entity, nameof(entity.Id));

        entity.AddDomainEvent(new TodoItemDeletedEvent(entity));
        await _todoItemRepository.DeleteAsync(entity, cancellationToken);
    }
}