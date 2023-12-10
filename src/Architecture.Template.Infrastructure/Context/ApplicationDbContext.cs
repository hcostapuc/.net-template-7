using System.Reflection;
using Ardalis.GuardClauses;
using Domain.Common;
using Infrastructure.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class ApplicationDbContext : DbContext
{
    protected readonly IMediator _mediator;
    public ApplicationDbContext(IMediator mediator,
                                DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        _mediator = mediator ?? Guard.Against.Null(mediator, nameof(mediator));
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<BaseAuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.Created = DateTime.Now;
                    break;

                case EntityState.Modified:
                    entry.Entity.LastModified = DateTime.Now;
                    break;
            }
        }
        await _mediator.DispatchDomainEvents(ChangeTracker.Context);

        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}