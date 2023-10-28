namespace Domain.Events;
public class TodoItemCreatedEvent : BaseEvent
{
    public TodoItemEntity TodoItem { get; }
    public TodoItemCreatedEvent(TodoItemEntity todoItem) =>
        TodoItem = todoItem ?? throw new ArgumentNullException(nameof(todoItem));
}
