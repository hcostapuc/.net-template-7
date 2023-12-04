using Domain.Entities;
using Domain.Interfaces.Repository;
using Infrastructure.Common;
using Infrastructure.Context;

namespace Infrastructure.Repository;
public sealed class WashOrderRepository : BaseRepository<WashOrderEntity>, IWashOrderRepository
{
    public WashOrderRepository(ApplicationDbContext context) : base(context)
    {

    }
}