namespace Domain.Events;
public class TodoItemDeletedEvent : BaseEvent
{
    public TodoItemEntity TodoItem { get; }
    public TodoItemDeletedEvent(TodoItemEntity todoItem) =>
        TodoItem = todoItem ?? throw new ArgumentNullException(nameof(todoItem));
}
