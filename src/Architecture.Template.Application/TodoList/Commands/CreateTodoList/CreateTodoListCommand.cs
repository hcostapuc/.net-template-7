namespace Application.TodoList.Commands.CreateTodoList;

public record class CreateTodoListCommand(string? Title) : IRequest<Guid>;