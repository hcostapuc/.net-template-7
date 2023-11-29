namespace Application.TodoItem.Commands.UpdateTodoItem;

public sealed record UpdateTodoItemCommand(Guid Id,
                                    string? Title,
                                    bool Done) : IRequest;