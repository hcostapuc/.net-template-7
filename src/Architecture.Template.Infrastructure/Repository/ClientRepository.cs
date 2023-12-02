using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Infrastructure.Common;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public sealed class ClientRepository: BaseRepository<ClientEntity>, IClientRepository
{
    public ClientRepository(ApplicationDbContext context) : base(context)
    {

    }

    public async Task<ClientEntity> SelectDetailAsync(Expression<Func<ClientEntity, bool>> expression, CancellationToken cancellationToken = default) =>
        await _dataset.AsNoTracking()
                 .Include(x => x.VehicleCollection)
                 .SingleOrDefaultAsync(expression, cancellationToken);
}
