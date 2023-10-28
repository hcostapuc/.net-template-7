namespace Domain.Entities;

public class TodoListEntity : BaseAuditableEntity
{
    public string? Title { get; set; }

    public Colour Colour { get; set; } = Colour.White;

    public IList<TodoItemEntity> Items { get; private set; } = new List<TodoItemEntity>();
}
