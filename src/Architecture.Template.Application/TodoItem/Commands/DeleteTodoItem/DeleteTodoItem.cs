namespace Application.TodoItem.Commands.DeleteTodoItem;

public sealed record DeleteTodoItemCommand(Guid Id) : IRequest;