using Domain.Entities;
using Domain.Interfaces.Repository;
using Infrastructure.Common;
using Infrastructure.Context;

namespace Infrastructure.Repository;

internal class TodoItemRepository : BaseRepository<TodoItemEntity>, ITodoItemRepository
{
    public TodoItemRepository(ApplicationDbContext context) : base(context)
    {

    }
}
