namespace Application.TodoItem.Commands.UpdateTodoItem;
internal static class UpdateTodoItemExtension
{
    internal static void UpdateEntityFieldsFrom(this TodoItemEntity todoItemEntity, UpdateTodoItemCommand updateTodoItemCommand)
    {
        todoItemEntity.Title = updateTodoItemCommand.Title;
        todoItemEntity.Done = updateTodoItemCommand.Done;
    }
}