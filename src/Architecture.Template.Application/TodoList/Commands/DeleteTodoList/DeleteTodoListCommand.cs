namespace Application.TodoList.Commands.DeleteTodoList;

public record class DeleteTodoListCommand(Guid Id) : IRequest;