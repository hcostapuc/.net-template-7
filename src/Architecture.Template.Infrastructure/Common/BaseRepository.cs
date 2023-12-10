using System.Linq.Expressions;
using Ardalis.GuardClauses;
using Domain.Common;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common;
public partial class BaseRepository<T> : IBaseRepository<T> where T : BaseAuditableEntity
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<T> _dataset;
    public BaseRepository(ApplicationDbContext context)
    {
        _context = context ?? Guard.Against.Null(context, nameof(context));
        _dataset = context.Set<T>();
    }
    public async Task<T> SelectAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default) =>
        await _dataset.AsNoTracking()
                 .SingleOrDefaultAsync(expression, cancellationToken);

    public async Task<IEnumerable<T>> SelectAllAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default) =>
         await _dataset.AsNoTracking()
                           .Where(expression)
                           .ToListAsync(cancellationToken);

    public async Task<IEnumerable<T>> SelectAllAsync(CancellationToken cancellationToken = default) =>
        await _dataset.AsNoTracking()
                           .ToListAsync(cancellationToken);
    public async Task<bool> ExistAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default) =>
       await _dataset.AnyAsync(expression, cancellationToken);
    public async Task<T> InsertAsync(T entity, CancellationToken cancellationToken)
    {
        await _dataset.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }
    public async Task<IEnumerable<T>> InsertRangeAsync(IEnumerable<T> entity, CancellationToken cancellationToken = default)
    {
        await _dataset.AddRangeAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }
    public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }
    public async Task<T> DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        if (entity is null)
            throw new ArgumentNullException(nameof(entity));

        _dataset.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }
    public async Task<bool> DeleteRangeAsync(IEnumerable<T> entityCollection, CancellationToken cancellationToken = default)
    {
        if (entityCollection is not T)
            throw new ArgumentNullException(nameof(entityCollection));

        _dataset.RemoveRange(entityCollection);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
    public async Task PurgeAsync(CancellationToken cancellationToken = default)
    {
        _context.RemoveRange(_dataset);
        await _context.SaveChangesAsync(cancellationToken);
    }

    #region DisposePattern
    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
                _context.Dispose();
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }


    #endregion
}