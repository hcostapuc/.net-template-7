using Domain.Entities;
using Domain.Interfaces.Repository;
using Infrastructure.Common;
using Infrastructure.Context;

namespace Infrastructure.Repository;

internal class TodoListRepository : BaseRepository<TodoListEntity>, ITodoListRepository
{
    public TodoListRepository(ApplicationDbContext context) : base(context)
    {

    }
}
