namespace Application.TodoList.Commands.UpdateTodoList;

public record class UpdateTodoListCommand(Guid Id,
                                    string? Title) : IRequest;