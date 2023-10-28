namespace Application.TodoItem.Commands.UpdateTodoItemDetail;
internal static class UpdateTodoItemDetailExtension
{
    internal static void UpdateDetailEntityFieldsFrom(this TodoItemEntity todoItemEntity, UpdateTodoItemDetailCommand updateTodoItemDetailCommand)
    {
        todoItemEntity.ListId = updateTodoItemDetailCommand.ListId;
        todoItemEntity.Priority = updateTodoItemDetailCommand.Priority;
        todoItemEntity.Note = updateTodoItemDetailCommand.Note;
    }
}