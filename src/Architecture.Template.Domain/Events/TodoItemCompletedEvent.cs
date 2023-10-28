namespace Domain.Events;
public class TodoItemCompletedEvent : BaseEvent
{
    public TodoItemEntity TodoItem { get; }
    public TodoItemCompletedEvent(TodoItemEntity todoItem) =>
        TodoItem = todoItem ?? throw new ArgumentNullException(nameof(todoItem));
}
