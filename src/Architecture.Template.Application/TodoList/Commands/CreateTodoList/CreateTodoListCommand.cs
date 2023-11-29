namespace Application.TodoList.Commands.CreateTodoList;

public sealed record CreateTodoListCommand(string? Title) : IRequest<Guid>;