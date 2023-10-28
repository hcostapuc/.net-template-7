namespace Application.TodoItem.Commands.UpdateTodoItem;

public record UpdateTodoItemCommand(Guid Id,
                                    string? Title,
                                    bool Done) : IRequest;