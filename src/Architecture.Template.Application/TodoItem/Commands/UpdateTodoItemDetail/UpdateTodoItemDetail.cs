using Domain.Enums;

namespace Application.TodoItem.Commands.UpdateTodoItemDetail;

public record UpdateTodoItemDetailCommand(Guid Id,
                                          Guid ListId,
                                          PriorityLevel Priority,
                                          string? Note) : IRequest;