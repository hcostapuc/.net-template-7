using System.Linq.Expressions;

namespace Domain.Common;

public interface IBaseRepository<T> : IDisposable where T : BaseAuditableEntity
{
    Task<T> SelectAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> SelectAllAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> SelectAllAsync(CancellationToken cancellationToken = default);
    Task<bool> ExistAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    Task<T> InsertAsync(T entity, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> InsertRangeAsync(IEnumerable<T> entityCollection, CancellationToken cancellationToken = default);
    Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
    Task<T> DeleteAsync(T entity, CancellationToken cancellationToken = default);
    Task<bool> DeleteRangeAsync(IEnumerable<T> entityCollection, CancellationToken cancellationToken = default);
    Task PurgeAsync(CancellationToken cancellationToken = default);
}