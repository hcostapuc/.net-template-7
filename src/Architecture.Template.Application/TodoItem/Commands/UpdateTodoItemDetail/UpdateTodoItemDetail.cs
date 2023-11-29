using Domain.Enums;

namespace Application.TodoItem.Commands.UpdateTodoItemDetail;

public sealed record UpdateTodoItemDetailCommand(Guid Id,
                                          Guid ListId,
                                          PriorityLevel Priority,
                                          string? Note) : IRequest;