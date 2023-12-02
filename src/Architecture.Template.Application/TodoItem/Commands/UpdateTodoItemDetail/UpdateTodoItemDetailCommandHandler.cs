using Domain.Interfaces.Repository;

namespace Application.TodoItem.Commands.UpdateTodoItemDetail;
public class UpdateTodoItemDetailCommandHandler : IRequestHandler<UpdateTodoItemDetailCommand>
{
    private readonly IClientRepository _todoItemRepository;

    public UpdateTodoItemDetailCommandHandler(IClientRepository todoItemRepository) =>
        _todoItemRepository = todoItemRepository ?? throw new ArgumentNullException(nameof(todoItemRepository));

    public async Task Handle(UpdateTodoItemDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _todoItemRepository.SelectAsync(x => x.Id == request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, entity, nameof(entity.Id));

        entity.UpdateDetailEntityFieldsFrom(request);

        await _todoItemRepository.UpdateAsync(entity, cancellationToken);
    }
}