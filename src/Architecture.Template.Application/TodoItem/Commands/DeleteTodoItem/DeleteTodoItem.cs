namespace Application.TodoItem.Commands.DeleteTodoItem;

public record DeleteTodoItemCommand(Guid Id) : IRequest;