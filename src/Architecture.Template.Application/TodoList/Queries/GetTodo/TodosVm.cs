namespace Application.TodoList.Queries.GetTodo;

public class TodosVm
{
    public IList<TodoListDto> Lists { get; set; } = new List<TodoListDto>();
}