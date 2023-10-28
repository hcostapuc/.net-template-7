using Application.Common.Mappings;

namespace Application.TodoList.Queries.GetTodo;

public record class TodoListDto : IMapFrom<TodoListEntity>
{
    public TodoListDto()
    {
        Items = new List<TodoItemDto>();
    }

    public Guid Id { get; set; }

    public string? Title { get; set; }

    public string? Colour { get; set; }

    public IList<TodoItemDto> Items { get; set; }
}