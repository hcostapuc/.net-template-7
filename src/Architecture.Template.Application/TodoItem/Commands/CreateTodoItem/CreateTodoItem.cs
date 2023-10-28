namespace Application.TodoItem.Commands.CreateTodoItem;

public record CreateTodoItemCommand(Guid ListId,
                                    string? Title) : IRequest<Guid>;