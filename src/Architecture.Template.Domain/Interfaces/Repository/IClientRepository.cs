using System.Linq.Expressions;

namespace Domain.Interfaces.Repository;

public interface IClientRepository : IBaseRepository<ClientEntity>
{
    Task<ClientEntity> SelectDetailAsync(Expression<Func<ClientEntity, bool>> expression, CancellationToken cancellationToken = default);
}