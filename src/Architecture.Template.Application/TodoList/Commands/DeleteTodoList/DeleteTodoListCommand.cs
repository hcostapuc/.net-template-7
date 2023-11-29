namespace Application.TodoList.Commands.DeleteTodoList;

public sealed record DeleteTodoListCommand(Guid Id) : IRequest;